using System;
using Enums;
using Models;
using UnityEngine;

namespace Databases.Menu.Impls
{
    [CreateAssetMenu(fileName = "AnimalsIconsDatabase", menuName = "Databases/Menu/AnimalsIconsDatabase")]
    public class AnimalsIconsDatabase : ScriptableObject, IAnimalsIconsDatabase
    {
        [SerializeField] private AnimalVo[] animalLevelInfos;
        
        public AnimalVo[] GetAnimalInfos => animalLevelInfos;

        public AnimalVo GetAnimalByType(EAnimalType type)
        {
            foreach (var animalLevelInfo  in animalLevelInfos)
            {
                if (animalLevelInfo.AnimalType == type)
                    return animalLevelInfo;
            }
            
            throw new Exception($"Cannot find sprite with type: {type}");
        }
    }
}
