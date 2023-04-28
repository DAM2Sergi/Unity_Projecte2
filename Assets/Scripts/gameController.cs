using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public static gameController instance;

    gameOverScreen gameOverScreen;
    scoreManager scoreManager;

    private void Awake()
    {
        instance = this;
    }

    public void GameOver()
    {
        scoreManager.instance.getScore();

        //int currentHealth = controller.health;

        //ScoreManager = FindObjectOfType<scoreManager>();
        //int puntuacio = scoreManager.score;

        int score = Convert.ToInt32(scoreManager);
        Debug.Log(score);
        gameOverScreen.instance.Setup(score);
    }
}
