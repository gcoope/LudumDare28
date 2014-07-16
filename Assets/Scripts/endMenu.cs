using UnityEngine;
using System.Collections;

public class endMenu : MonoBehaviour {

	public GameObject scoreHolderObj;
	public GUIText scoreText2;

	int score;
	
	// Use this for initialization
	void Start () {
		scoreHolderObj = GameObject.Find ("scoreHolder");
		if(scoreHolderObj) {
			score = scoreHolderObj.GetComponent<playerScore>().getScore();
		}
		scoreText2.text = "You earnt " + score + " dubloons!";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		if(GUI.Button(new Rect((Screen.width / 2) - 50, (Screen.height / 2) + 50, 100, 50), "Exit Game")) {
			Application.Quit();

		}
	}
}
