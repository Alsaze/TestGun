using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(1,LoadSceneMode.Single);
    }

    public void Credits()//титры
    {
        
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
