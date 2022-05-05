using System.Collections.Generic;
using Core.Windows;
using Core.Windows.Impls;
using UnityEngine;
using Zenject;

namespace Core.Collections
{
	public abstract class UiCollection<TView> : MonoBehaviour
		where TView : UiView
	{
		[SerializeField] private Transform parent;

		private List<TView> _itemsList = new List<TView>();
		
		[Inject] private IFactory<TView> _factory;
		
		public TView CreateItem()
		{
			var item = _factory.Create();
			item.transform.SetParent(parent, true);
			_itemsList.Add(item);
			return item;
		}

		public List<TView> GetItemsList => _itemsList;
	}
}