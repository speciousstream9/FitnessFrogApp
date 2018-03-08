using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lecture6_Example2 : MonoBehaviour {

	public GameObject uiTextObj;
	Text uiText;
	int lifePoints;
	const string FILE_NAME = "gameSave.txt";
	string path; 

	// int lifePoints;
	// Use this for initialization
	void Start () {
		lifePoints = 100;
		uiText = uiTextObj.GetComponent<Text> ();
		path = Application.persistentDataPath;
		Debug.Log (path);
	}
	
	// Update is called once per frame
	void Update () {
		uiText.text = "Life Points " + lifePoints; 
	}

	public void RandomGameEvent()
	{
		lifePoints = UnityEngine.Random.Range (0, 100);

	}

	public void SaveLifePoints ()
	{
		File.WriteAllText (path + "/" + FILE_NAME, lifePoints.ToString());
		Debug.Log ("File Saved Sucessfully");
	}
	public void LoadLifePoints()
	{
		if (File.Exists (path + "/" + FILE_NAME)) {
			lifePoints = Int32.Parse (File.ReadAllText (path + "/" + FILE_NAME));
			Debug.Log ("File Loaded Sucessfully");
		} else {
			Debug.Log ("File Not Found");

		}
	}

}
