using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static int streakCounter;

    private GameHandler game;

    public GameObject deadUI;

	// Use this for initialization
	void Awake () {

        game = FindObjectOfType<GameHandler>();

        Score.TrySetNewHighScore(200);
	}
	
	// Update is called once per frame
	void Update () {
		if(!game.alive)
        {
            Score.TrySetNewHighScore(Score.score);
            deadUI.SetActive(true);
        }
	}

    public static int GetStreak()
    {
        return streakCounter;
    }

    public static void AddStreak()
    {
        streakCounter += 1;
    }

    public static void Reset()
    {
        Score.score = 0;
        streakCounter = 0;
    }
}
