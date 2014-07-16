using UnityEngine;
using System.Collections;

public class wallHit : MonoBehaviour {

	public GameObject brokenWall;
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
			Destroy(col.gameObject);
			Destroy (gameObject);
			Instantiate (brokenWall, transform.position, transform.rotation);

			scoreHolderObj.GetComponent<playerScore>().addScore();
		}
	}
}
