using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWindows : MonoBehaviour {

    private Text scoreText;

	// Use this for initialization
	void Awake () {
        scoreText = transform.Find("ScoreText").GetComponent<Text>();
    }

    void Start()
    {
        Score.OnHighScoreChange += Score_OnHighScoreChange;
        UpdateHighScore();
    }
	
    private void Score_OnHighScoreChange(object sender, System.EventArgs e)
    {
        UpdateHighScore();
    }

    // Update is called once per frame
    void Update () {
        scoreText.text = "Score : " + Score.GetScore().ToString();
	}

    private void UpdateHighScore()
    {
        int highScore = Score.GetHighScore();
        transform.Find("HighText").GetComponent<Text>().text = "Pervious HighScore \n To BEAT !\n" + highScore.ToString();
    }
}
