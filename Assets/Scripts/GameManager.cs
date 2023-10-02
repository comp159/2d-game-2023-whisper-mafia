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
    [SerializeField] private GameObject gameOverObject;
	private bool gameOver = false;

	[SerializeField] private TextMeshProUGUI arrowCounter;
	private int maxArrowCount = 5;
	private int currentArrowCount = 5;
	
void Start(){
		arrowCounter.text = currentArrowCount.ToString();
}

    public void IncreaseScore()
    {
        score++;
        scoreCounter.text = score.ToString();
    }
	public void GameOver(){
		gameOverObject.gameObject.SetActive(true);
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
		if (currentArrowCount <= 0) return;
		currentArrowCount--;
		arrowCounter.text = currentArrowCount.ToString();
	}

	//Function increases currentArrowCount
	public void DestroyArrow()
	{
		if (currentArrowCount >= maxArrowCount) return;
		currentArrowCount++;
		arrowCounter.text = currentArrowCount.ToString();
	}
}

