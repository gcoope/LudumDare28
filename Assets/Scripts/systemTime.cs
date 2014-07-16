using UnityEngine;
using System.Collections;

public class systemTime : MonoBehaviour {

	// Author: George Coope
	// Title: System Time
	// Usage: Link a GUI Text and this script will neatly display the current system time

	public GUIText timeText;

	private string hours;
	private string minutes;
	private string seconds;

	void Update () {

		if(System.DateTime.Now.Hour < 10) {
			hours = "0" + System.DateTime.Now.Hour.ToString();
		} else {
			hours = System.DateTime.Now.Hour.ToString();
		}

		if(System.DateTime.Now.Minute < 10) {
			minutes = "0" + System.DateTime.Now.Minute.ToString();
		} else {
			minutes = System.DateTime.Now.Minute.ToString();
		}

		if(System.DateTime.Now.Second < 10) {
			seconds  = "0" + System.DateTime.Now.Second.ToString();
		} else {
			seconds = System.DateTime.Now.Second.ToString();
		}

		timeText.text = hours + ":" + minutes + ":" + seconds;
	}


}
