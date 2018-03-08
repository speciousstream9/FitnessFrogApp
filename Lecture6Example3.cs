using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct GameStatus
{
	public string checkpoint;
	public string playerName;
	public int level;
	public int lifePoints;
	public int score;
}

public class Lecture6_Example3 : MonoBehaviour {

	public GameObject uiTextObj;
	Text uiText;
	int lifePoints;
	const string FILE_NAME = "gameSave.txt";
	string path; 
	GameStatus progress;

	void initaliseProgress()
	{
		progress = new GameStatus ();
		progress.checkpoint = "Beginning";
		progress.playerName = "Laura"
		progress.lifePoints = 100;
		progress.level = 1;
		progress.score = 0;

	}

	// int lifePoints;
	// Use this for initialization
	void Start () {
		initaliseProgress ();
		uiText = uiTextObj.GetComponent<Text> ();
		path = Application.persistentDataPath;
		Debug.Log (path);
	}

	// Update is called once per frame
	void Update () {
		string message = "Checkpoint " + progress.checkpoint + "\n";
message += "Player "+ progress.playerName + "\n";
message += "Level " + progress.level + "\n";
message += "LifePoints  " + progress.lifePoints + "\n";
message += "Score  " + progress.score + "\n";
		uiText.text = "Life Points " + lifePoints; 
	}

	public void RandomGameEvent()
	{
		lifePoints = UnityEngine.Random.Range (0, 100);
		progress.score += RandomScoreIncr;

		if (progress.score > 100)
		{
			progress.score %= 100;
			progress.level++;
			progress.lifePoints += 50;
			progress.checkpoint + progress.level; 

	}

		public void SaveProgress()
	{
			string JsonString = JsonUtility.ToJson (progress);
			File.WriteAllText(path + "/" + 
		Debug.Log ("File Saved Sucessfully")
	}
	public void LoadProgress()
	{
		if (File.Exists (path + "/" + FILE_NAME)) {
						string jsonString = File.ReadAllText(path + "/" + FILE_NAME)
						progress new GameStatus();
						progress = JsonUtility.FromJson<GameStatus>(jsonString);
			Debug.Log ("File Loaded Sucessfully");
		} else {
						initaliseProgress();
			Debug.Log ("File Not Found");

		}
	}

}
