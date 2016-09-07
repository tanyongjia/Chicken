using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public float spawnTime = .5f;
	public Transform spawnLocation;
	public Slider timerSlider;
	public Text scoreText;
	public bool gameOver;
	public GameObject player;
	public GameObject falling;
	public GameObject puff;

	public int score = 0;
	float timer = 0;
	bool fallingState;
	bool fallingDone;
	Color pullColor;

	void Start () {
		InvokeRepeating ("SpawnChicken", spawnTime, spawnTime);
		pullColor = puff.GetComponent<SpriteRenderer> ().color;
	}

	void Update(){
		timer += Time.deltaTime;
		if (timer <= 5f) {
			timerSlider.value = timer;
			scoreText.text = "Score    " + score.ToString ();
		}

		if (timer > 5f && !fallingState) {
			gameOver = true;
			Destroy(scoreText.gameObject);
			Destroy(timerSlider.gameObject);
			falling.transform.position = new Vector2(player.transform.position.x, 9f);
			falling.AddComponent<Rigidbody2D>();
			fallingState = true;
		}

		if (falling.transform.position.y < - 1.1f && !fallingDone) {
			falling.GetComponent<Rigidbody2D>().isKinematic = true;
			puff.transform.position = player.transform.position;
			Destroy(player);
			puff.SetActive(true);
			fallingDone = true;
		}

		if (fallingDone) {
			pullColor.a -= Time.deltaTime * 0.5f;
			puff.GetComponent<SpriteRenderer>().color = pullColor;
		}
	}

	void SpawnChicken(){
		if (!gameOver) {
			Vector2 location = Camera.main.ScreenToWorldPoint (new Vector2 (Random.Range (0, Screen.width), Random.Range (Screen.height / 2f, Screen.height)));
			spawnLocation.position = location;

			GameObject obj = NewObjectPooler.current.GetPooledObject ();
			if (obj == null)
				return;
			obj.transform.position = spawnLocation.position;
			obj.transform.rotation = spawnLocation.rotation;
			obj.SetActive (true);
		}
	}
}
