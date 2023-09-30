using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreCounter;

    private int score;
	[SerializeField] private TextMeshProUGUI gameOverText;
	[SerializeField] private Button gameOverButton;
	//private bool gameOver = false;
void Start(){

		gameOverText.gameObject.SetActive(false);
		gameOverButton.gameObject.SetActive(false);
}

    public void IncreaseScore()
    {
        score++;
        scoreCounter.text = score.ToString();
    }

    public void ResetScore()
    {
        score = 0;
    }
	public void GameOver(){
		gameOverText.gameObject.SetActive(true);
		gameOverButton.gameObject.SetActive(true);
		//gameOver = true;
	}
	public void RestartGame() {
	    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}




}

