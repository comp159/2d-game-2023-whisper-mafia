using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreCounter;

    private int score;

    public void IncreaseScore()
    {
        score++;
        scoreCounter.text = score.ToString();
    }

    public void ResetScore()
    {
        score = 0;
    }
}