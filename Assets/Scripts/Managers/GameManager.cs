using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        ConfigManager.Enemy = new ObservableCollection<GameObject>();
        ConfigManager.Enemy.CollectionChanged += (sender, e) =>
        {
            if (ConfigManager.Enemy.Count == 10)
            {
                Lose();
            }
        };
    }

    private void Lose()
    { 
        ConfigManager.FireDamage = 1;
        ConfigManager.FireSpeed = 1;
        ConfigManager.Hp = 1;
        ConfigManager.MoveSpeedEnemie = 1;
        ConfigManager.FrequencySpawn = 5;
        ConfigManager.Enemy.Clear();
        ConfigManager.Gold = 0;
        ConfigManager.Time = 0;
        ConfigManager.Score = 0;
        ConfigManager.ElapsedTime = 0;
        
        Debug.Log("Game Over");
        SceneManager.LoadScene(0);
    }
}
