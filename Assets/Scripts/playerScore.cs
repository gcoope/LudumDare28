using UnityEngine;
using System.Collections;

public class playerScore : MonoBehaviour {

	private int pScore;
	public GameObject scoreText;
	private bool gameOver = false;

	void Start() {
		pScore = 0;
		scoreText = GameObject.Find("scoreText");
		scoreText.guiText.text = "0";
	}	

	void Awake() {
		DontDestroyOnLoad(gameObject);
	}

	void Update() {
		if(Application.loadedLevelName == "EndMenu") {
			gameOver = true;
		} else {
			gameOver = false;
		}
	}

	public int getScore() {
		return pScore;
	}

	public void addScore() {
		pScore++;
	}

	void OnGUI() {
		if(!gameOver && scoreText != null) {
			scoreText.guiText.text = pScore.ToString();
		}
	}
}
