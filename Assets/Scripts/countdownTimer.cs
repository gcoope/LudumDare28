using UnityEngine;
using System.Collections;

public class countdownTimer : MonoBehaviour {

	private float seconds = 60;
	public GUIText textMesh;
	
	void Start () {
		textMesh.text = seconds.ToString() + "s";
		InvokeRepeating ("Countdown", 1f, 1f);
	}
	
	void Countdown () {
		if (--seconds == 0) {
			CancelInvoke ("Countdown");
		}
		textMesh.text = seconds.ToString() + "s";
	}

	void Update() {
		if(seconds == 0) {
			Application.LoadLevel("EndMenu");
		}
	}
}
