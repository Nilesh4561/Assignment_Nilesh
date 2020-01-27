using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    private Text scoreText;

    // Use this for initialization
    void Awake()
    {
        scoreText = transform.Find("TextScore").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = Score.GetScore().ToString();
    }
}
