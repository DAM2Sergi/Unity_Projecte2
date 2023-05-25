using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public static gameController instance;

    gameOverScreen gameOverScreen;
    ScoreManager scoreManager;

    private void Awake()
    {
        instance = this;
        Debug.Log(instance);
    }

    public void GameOver()
    {
        
        ScoreManager.instance.getScore();

        //int currentHealth = controller.health;

        //ScoreManager = FindObjectOfType<scoreManager>();
        //int puntuacio = scoreManager.score;

        int score = Convert.ToInt32(scoreManager);
        gameOverScreen.Setup();
    }
}
