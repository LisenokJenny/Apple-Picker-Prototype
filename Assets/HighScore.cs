using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class HighScore : MonoBehaviour {
	static public int score = 1000;

	void Awake() {
		// если значение HighScore уже существует в PlayerPrefs, прочитать его
		if (PlayerPrefs.HasKey ("HighScore")) {
			score = PlayerPrefs.GetInt ("HighScore");
		}
		// сохранить высшее достижение HighScore в хранилище
		PlayerPrefs.SetInt ("Highscore", score);
	}

	void Update () {
		Text gt = this.GetComponent<Text> ();
		gt.text = "High Score: " + score;
		// обновить HighScore в PlayerPrefs, если необходимо
		if (score > PlayerPrefs.GetInt ("HighScore")) {
			PlayerPrefs.SetInt ("HighScore", score);
		}
	}
}
