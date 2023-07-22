using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;
using System.Collections;

namespace Controllers
{
    public class EnemySpawner : MonoBehaviour
    {
        //spawn position
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

        private void SpawnEnemy()
        {
            ConfigManager.Enemy.Add(Instantiate(GetEnemyPrefabs(), GetIsometricPosition(), Quaternion.identity, _enemySpawnwer));
        }

        void Start()
        {
            StartCoroutine(SpawnObjectWithRandomFrequency());
        }
        
        private IEnumerator SpawnObjectWithRandomFrequency()// частота спавна врагов
        {
            double _gameSpeedFactor = 0.05f; // сложность игры 
            double _minSpawnFrequency = 1f;
            while (true)
            {
                float _randomNumber = Random.Range(0.01f, 0.03f);
                SpawnEnemy();
                yield return new WaitForSeconds(ConfigManager.FrequencySpawn);
                if (ConfigManager.FrequencySpawn >= _minSpawnFrequency) 
                {
                    ConfigManager.FrequencySpawn -= (float) _gameSpeedFactor + _randomNumber;
                    ConfigManager.Hp += (float)_gameSpeedFactor;
                    ConfigManager.MoveSpeedEnemie += (float)_gameSpeedFactor;
                    
                    Debug.Log($"{ConfigManager.FrequencySpawn}|||||{ConfigManager.Hp}||||{ConfigManager.MoveSpeedEnemie}");
                }
            }
        }
    }
}
