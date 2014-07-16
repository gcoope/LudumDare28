using UnityEngine;
using System.Collections;

public class towerHit : MonoBehaviour {

	public GameObject brokenTower;
	public GameObject scoreHolderObj;

	// Use this for initialization
	void Start () {
		scoreHolderObj = GameObject.Find ("scoreHolder");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col) {
		if(col.collider.tag == "CannonBall") {
			GameObject tempT;
			Destroy(col.gameObject);
			tempT = Instantiate (brokenTower, transform.position, transform.rotation) as GameObject;
			tempT.rigidbody.AddExplosionForce(10f, transform.position, 10f);
			tempT.rigidbody.AddForce(0, 1, 0);
			tempT.transform.Rotate(90,0,0);
			Destroy (gameObject);

			scoreHolderObj.GetComponent<playerScore>().addScore();
		}
	}
}
