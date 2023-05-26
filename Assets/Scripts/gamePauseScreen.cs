using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamePauseScreen : MonoBehaviour
{
    public static gamePauseScreen instance;

    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void unSetup()
    {
        gameObject.SetActive(false);
    }

    public void ExitButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
