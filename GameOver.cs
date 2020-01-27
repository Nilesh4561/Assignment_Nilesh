using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameManager.Reset();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
