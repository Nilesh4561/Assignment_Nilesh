using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Streak : MonoBehaviour {

    private Text streakText;

	// Use this for initialization
	void Start () {
        streakText = transform.Find("StreakText").GetComponent<Text>();
        
	}
	
	// Update is called once per frame
	void Update () {
        streakText.text = "Streak : X" + GameManager.GetStreak().ToString();
	}
}
