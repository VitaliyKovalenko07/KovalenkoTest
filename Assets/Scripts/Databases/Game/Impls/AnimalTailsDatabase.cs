using Models;
using UnityEngine;

namespace Databases.Game.Impls
{
	[CreateAssetMenu(fileName = "AnimalTailsDatabase", menuName = "Databases/Game/AnimalTailsDatabase")]
	public class AnimalTailsDatabase : ScriptableObject, IAnimalTailsDatabase
	{
		[SerializeField] private AnimalTailVo[] animalTailVos;
		public AnimalTailVo[] GetAnimalTailIfo => animalTailVos;
	}
}