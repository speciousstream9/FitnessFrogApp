using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lecture6Example1 : MonoBehaviour {

	string checkpointName;
	int score;
	int lifePoints;
	int level;
	Text uiTextOut; 

	void SaveGameStatus()
	{
		PlayerPrefs.SetString ("checkpoint", checkpointName);
		PlayerPrefs.SetInt ("score", score);
		PlayerPrefs.SetInt ("lifeP", lifePoints);
		PlayerPrefs.SetInt ("level", level);
	}
	void LoadGameStatus()
	{
		checkpointName = PlayerPrefs.GetString ("checkpoint");
		score = PlayerPrefs.GetInt ("score");
		lifePoints = PlayerPrefs.GetInt ("lifeP");
		level = PlayerPrefs.GetInt ("level");
			}
	void Awake()
	{
		Debug.Log ("Awake");
		if (PlayerPrefs.GetString("checkpoint") == null || PlayerPrefs.GetString("checkpoint") == "") {
			checkpointName = "Beginning";
			score = 0;
			lifePoints = 100;
			level = 1;
		} else {
			LoadGameStatus();
		}
			
	}

	void OnApplicationPause (bool value)
	{
		if (value) {
			Debug.Log ("Paused");
			SaveGameStatus ();
		} else {
			Debug.Log ("Resume");
			LoadGameStatus ();
		}
	}

	void OnApplicationQuit()
	{
		Debug.Log ("Quit");
		SaveGameStatus ();
	}


	void ShowPlayerStatus()
	{
		string message = "Checkpoint " + checkpointName + "\n";
		message += "Score: " + score + "\n";
		message += "Life Points: " + lifePoints + "\n";
		message += "Level: " + level + "\n";

		uiTextOut.text = message; 
	}

	// Use this for initialization
	void Start () {
		checkpointName = "Beginning";
		score = 0;
		lifePoints = 100;
		level = 1;

		uiTextOut = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		score++;
		if (score > 1000) {
			level++;
			lifePoints += 10;
			score %= 1000;
		}

		ShowPlayerStatus ();

	}
}
