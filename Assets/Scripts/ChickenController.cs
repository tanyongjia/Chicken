using UnityEngine;
using System.Collections;

public class ChickenController : MonoBehaviour {

	void OnEnable(){
		Invoke ("Destroy", 1.5f);
	}
	
	void Destroy(){
		gameObject.SetActive (false);
	}
	
	void OnDisable(){
		CancelInvoke ();
	}

	void OnMouseDown(){
		RaycastHit2D hit = Physics2D.Raycast (new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y), -Vector2.up, 0f);
		if (hit.collider != null) {
			gameObject.SetActive (false);
			GameObject obj = (GameObject)Instantiate (Resources.Load ("chicken_3"), hit.transform.position, hit.transform.rotation);
			obj.AddComponent<Rigidbody2D> ();
		}
	}
}
