using UnityEngine;

namespace Core.Windows.Impls
{
	public abstract class UiView : MonoBehaviour, IUiView
	{
		public void Show() => gameObject.SetActive(true);
		public void Hide() => gameObject.SetActive(false);
	}
}