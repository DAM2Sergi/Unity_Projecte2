using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameOverScreen : MonoBehaviour
{
    public static gameOverScreen instance;

    public Text pointsText;
    public int finalscore;

    private void Awake()
    {
        instance = this;
    }

    public void setScore(int score)
    {
        finalscore = score;
    }

    public void Setup(int score)
    {
        gameObject.SetActive(false);
        pointsText.text = score.ToString() + " POINTS";
    }
}
