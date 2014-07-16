using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		if(GUI.Button(new Rect((Screen.width / 2) - 50, (Screen.height / 2) - 100, 100, 50), "Play Game")) {
			Application.LoadLevel("Main");
		}
	}
}
