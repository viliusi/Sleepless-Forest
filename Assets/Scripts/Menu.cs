using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public void start()
    {
        SceneManager.LoadScene(2);
    }

    public void quit()
    {
        Application.Quit();
    }

    public void controls()
    {
        SceneManager.LoadScene(1);
    }

    public void menu()
    { 
        SceneManager.LoadScene(0);
    }
}