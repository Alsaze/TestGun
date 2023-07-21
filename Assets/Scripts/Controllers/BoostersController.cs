using System;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class BoostersController : MonoBehaviour
    {
        private int _priceBoosterUpgradeWeapon = 1;
        [SerializeField] private Text _priceBoosterUpgradeWeaponText;

        private int _priceBoosterKillAllEnemys = 2;
        [SerializeField] private Text _priceBoosterKillAllEnemysText;

        private int _priceBoosterFreezeSpawnEnemies = 3;
        [SerializeField] private Text _priceBoosterFreezeSpawnEnemiesText;

        private void SetUI()
        {
            _priceBoosterUpgradeWeaponText.text = _priceBoosterUpgradeWeapon.ToString();
            _priceBoosterKillAllEnemysText.text = _priceBoosterKillAllEnemys.ToString();
            _priceBoosterFreezeSpawnEnemiesText.text = _priceBoosterFreezeSpawnEnemies.ToString();
        }

        private void Update()
        {
            SetUI();

            //прокачка оружия
            if (Input.GetKeyDown(KeyCode.G) && ConfigManager.Gold >= _priceBoosterUpgradeWeapon)
            {
                BoosterUpgradeWeapon();
            }

            //замарозка спавна на 3 секунды
            if (Input.GetKeyDown(KeyCode.R) && ConfigManager.Gold >= _priceBoosterFreezeSpawnEnemies)
            {
                BoosterFreezeSpawnEnemies();
            }

            //убийство всех врагов на сцене
            if (Input.GetKeyDown(KeyCode.T) && ConfigManager.Gold >= _priceBoosterKillAllEnemys)
            {
                BoosterKillAllEnemys();
            }
        }

        private void Start()
        {
            ConfigManager.FrequencySpawn = 3;
        }

        #region Boosters

        private void BoosterUpgradeWeapon()
        {
            ConfigManager.Gold -= _priceBoosterUpgradeWeapon;

            ConfigManager.FireDamage += 1;
            ConfigManager.FireSpeed -= 0.1f;
        }

        private void BoosterKillAllEnemys()
        {
            ConfigManager.Gold -= _priceBoosterKillAllEnemys;
            for (int i = 0; i < ConfigManager.Enemy.Count; i++)
            {
                Destroy(ConfigManager.Enemy[i]);

                ConfigManager.Score += 100;
                ConfigManager.Gold += 1;
            }

            ConfigManager.Enemy.Clear();
        }

        private void BoosterFreezeSpawnEnemies() //не работает !!!!
        {
            ConfigManager.Gold -= _priceBoosterFreezeSpawnEnemies;

            ConfigManager.FrequencySpawn = 5;

            Debug.Log(ConfigManager.FrequencySpawn);
        }

        #endregion
    }
}
