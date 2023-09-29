using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

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
        print(score);
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
