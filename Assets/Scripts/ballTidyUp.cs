using UnityEngine;
using System.Collections;

public class ballTidyUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < -3) {
			DestroyObject(gameObject);
		}

		Destroy (gameObject, 3);
	}
}
