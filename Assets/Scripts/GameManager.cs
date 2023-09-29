using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int score;

    public void IncreaseScore()
    {
        score++;
        print(score);
    }

    public void ResetScore()
    {
        score = 0;
    }
}
