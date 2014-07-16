using UnityEngine;
using System.Collections;

public class coinSpinScript : MonoBehaviour {

	public Texture2D[] coinSprites;
	private Texture2D currentSprite;

	public GUIText scoreText;


	float curFrame = 0f;
	float frameScrollSpeed = 4f;

	
	void OnGUI(){

		curFrame += Time.deltaTime * frameScrollSpeed;

		int index = Mathf.FloorToInt (curFrame) % coinSprites.Length;

		if(scoreText != null) {
			GUI.DrawTexture(new Rect(scoreText.transform.position.x + 31, scoreText.transform.position.y+ 35, 30, 30) ,coinSprites[index]);
		}
	}
}
