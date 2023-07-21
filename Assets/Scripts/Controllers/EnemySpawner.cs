using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Controllers
{
    public class EnemySpawner : MonoBehaviour
    {
        //частоат спавна
        
        [SerializeField] private GameObject minPosition;
        [SerializeField] private GameObject maxPosition;
        //EnemyPrefabs
        [SerializeField] private GameObject _zombiePrefab;

        [SerializeField] private GameObject _mob1Prefab;

        [SerializeField] private GameObject _mob2Prefab;
        
        private Transform _enemySpawnwer;
        private void Awake()
        {
            Transform _enemySpawnwer = GetComponent<Transform>();
        }

        private GameObject GetEnemyPrefabs()
        {
            int randomNumber = Random.Range(0, 2);
            if (randomNumber == 0)
            {
                return _zombiePrefab;
            }

            if (randomNumber == 1)
            {
                return _mob1Prefab;
            }

            if (randomNumber == 2)
            {
                return _mob2Prefab;
            }

            return _zombiePrefab;
        }

        public Vector3Int GetIsometricPosition()
        {
            int randomX = (int)Random.Range(minPosition.transform.position.x, maxPosition.transform.position.x);
            int randomZ = (int)Random.Range(minPosition.transform.position.z, maxPosition.transform.position.z);
            int posY = 2;
            Vector3Int newPosition = new Vector3Int(randomX, posY, randomZ);

            return newPosition;
        }

        private void CreateEnemy()
        {
            ConfigManager.Enemy.Add(Instantiate(GetEnemyPrefabs(), GetIsometricPosition(), Quaternion.identity, _enemySpawnwer));
        }

        void Start()
        {
            InvokeRepeating("CreateEnemy", 0f,ConfigManager.FrequencySpawn );
        }
    }
}
