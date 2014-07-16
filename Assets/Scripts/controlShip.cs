using UnityEngine;
using System.Collections;

public class controlShip : MonoBehaviour {

	public Camera mainCamera;
	public Camera shipCamera;

	public Transform player;
	public Transform ship;
	public Transform playerHolder;

	public GameObject ballObj;
	public Transform ballSpawner;
	public Transform leftBallSpawner1;
	public Transform leftBallSpawner2;
	public Transform rightBallSpawner1;
	public Transform rightBallSpawner2;
	
	public Transform ballHolder;

	public Transform invisCannonObj;
	public Transform hat;

	bool isSailing = false;
	bool canSail = false;

	float initialSpeed = 8f;
	float moveSpeed = 8f;
	float maxSpeed = 16f;
	float turnSpeed = 6f;

	MouseLook cml;

	void Start () {
		cml = player.GetComponent<MouseLook>();
	}
	void Update () {
	
		// Enter ship with E, exit with Q
		if(Input.GetKey(KeyCode.E) && canSail == true){
			isSailing = true; // disable mouse look when sailing
			cml.enabled = false;
		} 
		else if(Input.GetKey(KeyCode.Q) && isSailing) {
			isSailing = false;
			cml.enabled = true;
			player.position = playerHolder.position;
		}

		if(Input.GetKeyUp(KeyCode.F12)) {
			Application.CaptureScreenshot("LD28_screenshot.png");
		}

		if(isSailing) {
			steerShip();
			swapCameras("ship");
			player.rotation = playerHolder.rotation;
			player.position = playerHolder.position; // Put player behind wheel
		} else {
			swapCameras("player");
		}

		manuallyFireCannon();

		easterEgg();
		noSwimming();
	}

	void swapCameras(string cam) {
		if(cam == "ship") {
			mainCamera.enabled = false;
			shipCamera.enabled = true;
		}
		else if(cam == "player") {
			mainCamera.enabled = true;
			shipCamera.enabled = false;
		}
	}

	void steerShip() {

		// Forward/Backwards
		if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)){ 
			ship.transform.Translate(0, 0, 1 * Time.deltaTime * moveSpeed);
			// Acceleration
			if(moveSpeed < maxSpeed) {
				moveSpeed += 0.05f;
			}
		}
		if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)){ 
			ship.transform.Translate(0, 0, -1 * Time.deltaTime * moveSpeed);
		}
		// Turning
		if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
			ship.Rotate(0, -5 * Time.deltaTime * turnSpeed, 0);
		}		
		if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
			ship.Rotate(0, 5 * Time.deltaTime * turnSpeed, 0);
		}

		// spacebar center cannon
		if(Input.GetKeyUp(KeyCode.Space)) {
			fireCannon();
		}

		// left click left cannons
		if(Input.GetMouseButtonDown(0)) {
			fireLeftCannons();
		}	

		// right click right cannons
		if(Input.GetMouseButtonDown(1)) {
			fireRightCannons();
		}	

		if(Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)){ 
			moveSpeed = initialSpeed;
		}
	}

	void OnTriggerEnter(Collider col) {
		if(col.tag == "Player") {
			canSail = true;
		}
	}

	void OnTriggerExit(Collider col) {
		if(col.tag == "Player") {
			canSail = false;
		}
	}

	void fireCannon() {
		GameObject b;
		b = Instantiate(ballObj, ballSpawner.transform.position, ballSpawner.rotation) as GameObject;
		b.transform.parent = ballHolder;
		b.rigidbody.AddRelativeForce(0, 0, 3000);
	}

	void fireLeftCannons() {
		GameObject b;
		GameObject b2;
		b = Instantiate(ballObj, leftBallSpawner1.transform.position, leftBallSpawner1.rotation) as GameObject;
		b.transform.parent = ballHolder;
		b.rigidbody.AddRelativeForce(0, 0, 3000);

		b2 = Instantiate(ballObj, leftBallSpawner2.transform.position, leftBallSpawner2.rotation) as GameObject;
		b2.transform.parent = ballHolder;
		b2.rigidbody.AddRelativeForce(0, 0, 3000);
	}

	void fireRightCannons() {
		GameObject b;
		GameObject b2;
		b = Instantiate(ballObj, rightBallSpawner1.transform.position, rightBallSpawner1.rotation) as GameObject;
		b.transform.parent = ballHolder;
		b.rigidbody.AddRelativeForce(0, 0, 3000);
		
		b2 = Instantiate(ballObj, rightBallSpawner2.transform.position, rightBallSpawner2.rotation) as GameObject;
		b2.transform.parent = ballHolder;
		b2.rigidbody.AddRelativeForce(0, 0, 3000);
	}
	
	void noSwimming() {
		if(player.position.y < 0) {
			player.position = playerHolder.position;
		}
	}

	void manuallyFireCannon() {
		float dpDistance = Vector3.Distance(player.position, invisCannonObj.position);
		if(dpDistance < 3 && Input.GetKeyUp(KeyCode.E) && !isSailing) {
			fireCannon();
		}
		
	}

	void easterEgg() {
		if(Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.F9)) {
			hat.renderer.enabled = true;
		}
	}	
}
