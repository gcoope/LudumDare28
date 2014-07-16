using UnityEngine;
using System.Collections;

public class shipBreak : MonoBehaviour {

	public GameObject brokenShip;
	public GameObject ship;
	public Camera shipCam;

	public Camera gameOverCamera;
	public GUIText gameOverText;
	
	private bool gameOver = false;

	// Use this for initialization
	void Start () {
		//
	}
	
	// Update is called once per frame
	void Update () {
		//
	}

	public bool isGameOver() {
		return gameOver;
	}
	

	void OnTriggerEnter(Collider col) {
		if(col.gameObject.tag == "Boat") {

			gameOver = true;
			GameObject tempShip;
			Destroy(ship);
			tempShip = Instantiate (brokenShip, new Vector3(ship.transform.position.x, ship.transform.position.y + 3, ship.transform.position.z), ship.transform.rotation) as GameObject;
			tempShip.transform.Rotate(0, 180, 0);
			tempShip.rigidbody.AddExplosionForce(10f, ship.transform.position, 10f);

			Camera tempCam;
			tempCam = Instantiate(gameOverCamera, shipCam.transform.position, shipCam.transform.rotation) as Camera;
			tempCam.enabled = true;


			gameOverCamera.enabled = true;
			gameOverText.enabled = true;
		}
	}

	void OnGUI() {
		if(gameOver) {
			if(GUI.Button(new Rect((Screen.width / 2) - 50, (Screen.height / 2) - 100, 100, 50), "Exit")) {
				Application.Quit();
			}
		}
	}
}
