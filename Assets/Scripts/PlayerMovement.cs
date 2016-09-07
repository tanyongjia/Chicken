using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public GameObject gameManager;
	public float movementSpeed = 5f;
	Vector2 playerMovement;
	bool facingRight = true;
	bool gameState = false;
	float h;

	void Update () {
		gameState = gameManager.GetComponent<GameManager> ().gameOver;
		if (gameState) {
			GetComponent<Rigidbody2D> ().isKinematic = true;
		} else {
			h = Input.GetAxisRaw ("Horizontal");
			playerMovement.Set (h, 0f);
			playerMovement = playerMovement.normalized * movementSpeed * Time.deltaTime;
			if (playerMovement.x < 0 && facingRight) {
				facingRight = false;
				Flip ();
			}
			if (playerMovement.x > 0 && !facingRight) {
				facingRight = true;
				Flip ();
			}
			GetComponent<Rigidbody2D> ().MovePosition ((Vector2)transform.position + playerMovement);
		}
	}

	void Flip(){
		Vector2 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
