using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isEnd = false;
	public float restartDelay = 1f;
    public GameObject completeLevelUI;

    public void FinishLevel()
    {
        completeLevelUI.SetActive(true);
    }


    public void EndGame()
    {
        if (isEnd == false)
        {
            isEnd = true;
            Debug.Log("Game over !");
			Invoke("Restart", restartDelay);
		}
    }

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);

	}
}
