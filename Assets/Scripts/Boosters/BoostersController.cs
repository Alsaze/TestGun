using System;
using Controllers;
using UnityEngine;
using UnityEngine.UI;

public class BoostersController : MonoBehaviour
{
    [SerializeField] private Text _priceBoosterUpgradeWeaponText;
    [SerializeField] private Text _priceBoosterKillAllEnemysText;
    [SerializeField] private Text _priceBoosterFreezeSpawnEnemiesText;

    private Booster _upgradeWeaponBooster;
    private Booster _killAllEnemiesBooster;
    private Booster _freezeSpawnEnemiesBooster;

    private void Start()
    {
        _upgradeWeaponBooster = new UpgradeWeaponBooster(1);
        _killAllEnemiesBooster = new KillAllEnemiesBooster(2);
        _freezeSpawnEnemiesBooster = new FreezeSpawnEnemiesBooster(3);
    }

    private void Update()
    {
        SetUI();
        
        _upgradeWeaponBooster.Update();

        _freezeSpawnEnemiesBooster.Update();
        
        _killAllEnemiesBooster.Update();

    }

    private void SetUI()
    {
        _priceBoosterUpgradeWeaponText.text = _upgradeWeaponBooster.Price.ToString();
        _priceBoosterKillAllEnemysText.text = _killAllEnemiesBooster.Price.ToString();
        _priceBoosterFreezeSpawnEnemiesText.text = _freezeSpawnEnemiesBooster.Price.ToString();
    }
}