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
	private bool gameOver = false;

	[SerializeField] private TextMeshProUGUI arrowCounter;
	private int maxArrowCount = 5;
	private int currentArrowCount;
	
void Start(){

		gameOverText.gameObject.SetActive(false);
		gameOverButton.gameObject.SetActive(false);
		currentArrowCount = 5;
		arrowCounter.text = currentArrowCount.ToString();
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
		gameOver = true;

		//Deleting Existing Enemys
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		foreach(GameObject enemy in enemies){
			Destroy(enemy);
		}
	}
	public void RestartGame() {
	    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	public bool getGameOver(){
		return gameOver;
	}

	//Function decrements currentArrowCount
	public void ArrowShot()
	{
		if (currentArrowCount > 0)
		{
			currentArrowCount--;
			arrowCounter.text = currentArrowCount.ToString();

		}
	}

	//Function increases currentArrowCount
	public void DestroyArrow()
	{
		if (currentArrowCount < maxArrowCount)
		{
			currentArrowCount++;
			arrowCounter.text = currentArrowCount.ToString();
		}
	}
}

