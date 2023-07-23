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
        [SerializeField] private GameObject _minPosition;
        [SerializeField] private GameObject _maxPosition;
        //EnemyPrefabs
        [SerializeField] private GameObject _zombiePrefab;

        [SerializeField] private GameObject _mob1Prefab;

        [SerializeField] private GameObject _mob2Prefab;
        
        private Transform _enemySpawnwer;
        private void Awake()
        {
            Transform _enemySpawnwer = GetComponent<Transform>();
        }

        private GameObject GetEnemyPrefabs()//можно много мобов вставить, но я не успел 
        {
            int randomNumber = Random.Range(0, 3);
            switch (randomNumber)
            {
                case 0:
                    return _zombiePrefab;
                case 1:
                    return _mob1Prefab;
                case 2:
                    return _mob2Prefab;
                default:
                    return _zombiePrefab;
            }
        }

        public Vector3Int GetIsometricPosition()
        {
            int randomX = (int)Random.Range(_minPosition.transform.position.x, _maxPosition.transform.position.x);
            int randomZ = (int)Random.Range(_minPosition.transform.position.z, _maxPosition.transform.position.z);
            int posY = 1;
            Vector3Int newPosition = new Vector3Int(randomX, posY, randomZ);

            return newPosition;
        }

        private void SpawnEnemy()
        {
            if (ConfigManager.CanSpawn)
            {
                ConfigManager.Enemy.Add(Instantiate(GetEnemyPrefabs(), GetIsometricPosition(), Quaternion.identity, _enemySpawnwer));
            }
            else
            {
                StartCoroutine("FreezeSpawn");
            }
        }

        private IEnumerator FreezeSpawn()
        {
            float freezeSpawn = 3;
            yield return new WaitForSeconds(freezeSpawn+ConfigManager.FrequencySpawn);
            ConfigManager.CanSpawn = true;
        }

        void Start()
        {
            StartCoroutine(SpawnObjectWithRandomFrequency());
        }
        
        private IEnumerator SpawnObjectWithRandomFrequency()// повышение сложности игры в зависимости от времени
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
                    ConfigManager.FrequencySpawn -= (float)_gameSpeedFactor + _randomNumber;
                    ConfigManager.Hp += (float)_gameSpeedFactor;
                    ConfigManager.MoveSpeedEnemie += (float)_gameSpeedFactor;

                    Debug.Log(
                        $"FrequencySpawn {ConfigManager.FrequencySpawn}|||||HP {ConfigManager.Hp}||||MoveSpeed {ConfigManager.MoveSpeedEnemie}");
                }
            }
        }
    }
}
