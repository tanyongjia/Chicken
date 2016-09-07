using UnityEngine;
using System.Collections;

public class PickedUp : MonoBehaviour {

	GameObject gameManager;

	void Start(){
		gameManager = GameObject.Find ("GameManager");
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			gameManager.GetComponent<GameManager>().score++;
			Destroy(gameObject);
		}
	}
	
	void Update(){
		if (gameObject.transform.position.y < -5) {
			Destroy (gameObject);
		}
	}

}
