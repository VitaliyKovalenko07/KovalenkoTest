using Enums;
using Signals;
using UniRx;
using Zenject;

namespace Services.GameStartBuffer.Impls
{
	public class GameStartBuffer : IInitializable, IGameStartBuffer
	{
		private readonly SignalBus _signalBus;
		private readonly CompositeDisposable _disposable = new CompositeDisposable();

		private EAnimalType currentAnimal;

		public EAnimalType CurrentAnimal => currentAnimal;


		public GameStartBuffer(SignalBus signalBus)
		{
			_signalBus = signalBus;
		}

		public void Initialize()
		{
			_signalBus.GetStream<SignalGameSelect>().Subscribe(OnSetGameLevel).AddTo(_disposable);
		}

		private void OnSetGameLevel(SignalGameSelect signal)
		{
			currentAnimal = signal.AnimalType;
		}
	}
}