using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Score : MonoBehaviour{

    public static event EventHandler OnHighScoreChange;

    public static int score;

    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt("highScore", 0);
    }

    public static bool TrySetNewHighScore()
    {
        return TrySetNewHighScore(score);
    }

    public static bool TrySetNewHighScore(int score)
    {
        int highScore = GetHighScore();
        if(score > highScore)
        {
            PlayerPrefs.SetInt("highScore", score);
            PlayerPrefs.Save();
            if(OnHighScoreChange != null)
            {
                OnHighScoreChange(null, EventArgs.Empty);
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    public static int GetScore()
    {
        return score;
    }

    public static void AddScore()
    {
        score += 10 * GameManager.streakCounter;
    }
}
