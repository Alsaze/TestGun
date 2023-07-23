using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _creditsMenu;
    [SerializeField] private Text _textScore;
    [SerializeField] private Text _textTime;

    public void Play()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void Credits() //титры
    {
        _creditsMenu.SetActive(true);
    }

    private void Update()
    {
        _textScore.text = "Your best Score: " + ConfigManager.BestScore.ToString();
        _textTime.text = "Your best Time: " + ConfigManager.BestElapsedTimeTime.ToString();
    }

    public void QuitCredits()
    {
        _creditsMenu.SetActive(false);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
