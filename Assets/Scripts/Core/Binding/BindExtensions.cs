using Core.Windows;
using Core.Windows.Impls;
using UnityEngine;
using Zenject;

namespace Core.Binding
{
	public static class BindExtensions
	{
		public static void BindUiView<T, TU>(this DiContainer container, TU viewPrefab, Transform parent)
			where TU : MonoBehaviour, IUiView
			where T : UiController<TU>
		{
			container.BindInterfacesAndSelfTo<T>().AsSingle();
			container.BindInterfacesAndSelfTo<TU>()
				.FromComponentInNewPrefab(viewPrefab)
				.UnderTransform(parent).AsSingle();
		}
	}
}