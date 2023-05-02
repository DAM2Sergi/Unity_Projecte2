using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameOverScreen : MonoBehaviour
{
    public static gameOverScreen instance;

    public Text pointsText;
    public Text finalscore;

    public void setScore(int score)
    {
        finalscore.text = score.ToString();
    }

    public void Setup()
    {
        gameObject.SetActive(true);
    }
}
