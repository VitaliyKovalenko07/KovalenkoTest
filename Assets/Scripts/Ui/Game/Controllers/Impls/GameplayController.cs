using System;
using System.Collections.Generic;
using Core.Windows.Impls;
using Databases.Game;
using Enums;
using Models;
using Services.GameStartBuffer;
using Ui.Game.Views;
using Ui.Game.Views.Items;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Ui.Game.Controllers.Impls
{
	public class GameplayController : UiController<GameplayView>, IGameplayController, IInitializable, IDisposable 
	{
		private readonly IAnimalTailsDatabase _animalTailsDatabase;
		private readonly ISoundsDatabase _soundsDatabase;
		private readonly IAnimalVoiceActingDatabase _animalVoiceActingDatabase;
		private readonly IAnimationParametersDatabase _animationParametersDatabase;
		private readonly IAnimalsSkeletonDatabase _animalsSkeletonDatabase;
		private readonly ISpineAnimationDatabase _spineAnimationDatabase;
		private readonly IGameStartBuffer _gameStartBuffer;
		private readonly IGameplaySettings _gameplaySettings;

		private EAnimalType _currentAnimal;
		private bool _isOverOne;
		private int _counter;

		private Dictionary<EAnimalType, AnimalTailItemView> animalTailItemViews = 
			new Dictionary<EAnimalType, AnimalTailItemView>();

		public GameplayController
		(
			IAnimalTailsDatabase animalTailsDatabase,
			ISoundsDatabase soundsDatabase,
			IAnimalVoiceActingDatabase animalVoiceActingDatabase,
			IAnimationParametersDatabase animationParametersDatabase,
			IAnimalsSkeletonDatabase animalsSkeletonDatabase,
			ISpineAnimationDatabase spineAnimationDatabase,
			IGameStartBuffer gameStartBuffer,
			IGameplaySettings gameplaySettings
		)
		{
			_animalTailsDatabase = animalTailsDatabase;
			_soundsDatabase = soundsDatabase;
			_animalVoiceActingDatabase = animalVoiceActingDatabase;
			_animationParametersDatabase = animationParametersDatabase;
			_animalsSkeletonDatabase = animalsSkeletonDatabase;
			_spineAnimationDatabase = spineAnimationDatabase;
			_gameStartBuffer = gameStartBuffer;
			_gameplaySettings = gameplaySettings;
		}

		public void Initialize()
		{
			_currentAnimal = _gameStartBuffer.CurrentAnimal;

			SetTails();
			SetAnimal();

			View.BackButton.OnClickAsObservable().Subscribe(_ => OnBackClick());
			View.AnimalButton.OnClickAsObservable().Subscribe(_ => OnAnimalClick());

			Observable.Timer(TimeSpan.FromSeconds(1)).Repeat().Subscribe(_ => Tick());
			
		}

		private void Tick()
		{
			_counter++;
				
			if (_counter == _gameplaySettings.GetTimeToInactive)
				OnPlayerInactive(true);
			if (_counter == _gameplaySettings.GetTimeToInactive + _gameplaySettings.GetTimeToSleep)
				OnPlayerSleep(true);
		}

		public void Dispose()
		{
		}

		private void SetTails()
		{
			foreach (var tailInfo in _animalTailsDatabase.GetAnimalTailIfo)
			{
				var itemView = CreateTailView(tailInfo.PanelType);

				itemView.SetAnimalTail(tailInfo.AnimalTail);
				itemView.transform.localPosition = tailInfo.SpawnPlace;
				itemView.TailButton.OnClickAsObservable().Subscribe(_ => OnTailClick(tailInfo, itemView));

				animalTailItemViews.Add(tailInfo.AnimalType, itemView);
			}
		}

		private void SetAnimal()
		{
			View.SetAnimalSkeleton(_animalsSkeletonDatabase.GetSkeletonByType(_currentAnimal));
			_animalVoiceActingDatabase.PlayAnimalVoiceByType(_currentAnimal);
			View.StartSkeletonAnimation(_spineAnimationDatabase.GetAnimationByType
				(_currentAnimal, EAnimationType.Idle), true);
		}

		AnimalTailItemView CreateTailView(EPanelType type) => type == EPanelType.Left
			? View.LeftPanelTailsCollection.CreateItem()
			: View.RightPanelTailsCollection.CreateItem();

		private void OnTailClick(AnimalTailVo tailInfo, AnimalTailItemView itemView)
		{
			itemView.TailOutline.enabled = true;
			OnPlayerActive();

			if (_currentAnimal == tailInfo.AnimalType)
			{
				var audio = _soundsDatabase.GatRandomCorrectAudio;
				AudioSource.PlayClipAtPoint(audio, Vector3.zero);

				View.StartSkeletonAnimation(
					_spineAnimationDatabase.GetAnimationByType(_currentAnimal, EAnimationType.CorrectEmotion),
					false, () => OnCurrentTailTap(itemView), audio.length);

				_isOverOne = false;
			}
			else
			{
				var audio = _soundsDatabase.GetRandomIncorrectAudio;
				AudioSource.PlayClipAtPoint(audio, Vector3.zero);

				if (!_isOverOne)
				{
					View.StartSkeletonAnimation(
						_spineAnimationDatabase.GetAnimationByType(_currentAnimal, EAnimationType.IncorrectEmotion),
						false, () => itemView.TailOutline.enabled = false, audio.length);

					_isOverOne = true;
				}
				else
				{
					View.StartSkeletonAnimation(
						_spineAnimationDatabase.GetAnimationByType(_currentAnimal, EAnimationType.SadEmotion),
						true, () => itemView.TailOutline.enabled = false, audio.length);
				}
			}
		}

		private void OnAnimalClick()
		{
			View.StartSkeletonAnimation(
				_spineAnimationDatabase.GetAnimationByType(_currentAnimal, EAnimationType.StandEmotion), false);
			OnPlayerActive();
		}

		private void OnCurrentTailTap(AnimalTailItemView itemView)
		{
			itemView.TailOutline.enabled = false;
			OnPlayerActive();
			OnBackClick();
		}

		private void OnBackClick()
		{
			SceneManager.LoadScene("MenuScene");
		}

		private void OnPlayerActive()
		{
			_counter = 0;
			OnPlayerInactive(false);
			OnPlayerSleep(false);
		}
		
		private void OnPlayerInactive(bool isInactive)
		{
			if (isInactive)
				_animalVoiceActingDatabase.PlayAnimalVoiceByType(_currentAnimal);

			foreach (var itemView in animalTailItemViews)
			{
				itemView.Value.StartTailAnimation(_animationParametersDatabase.TailAnimationParameters, isInactive);
			}
		}

		private void OnPlayerSleep(bool isInactive)
		{
			foreach (var itemView in animalTailItemViews)
			{
				if (itemView.Key == _currentAnimal)
				{
					itemView.Value.SetActiveHelpFinger(isInactive);
				}
			}
		}
	}
}