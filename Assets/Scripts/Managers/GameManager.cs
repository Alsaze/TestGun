using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        ConfigManager.FireDamage = 1;
        ConfigManager.FireSpeed = 1;
        ConfigManager.Hp = 1;
        ConfigManager.Enemy = new List<GameObject>();
        ConfigManager.Gold = 0;
        ConfigManager.ElapsedTime = 0;
    }
    

    private void Update()
    {
        Lose();
    }

    private void Lose()
    {
        
        if (ConfigManager.Enemy.Count == 10)
        {
            Debug.Log("Game Over");
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}
