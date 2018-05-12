using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float speed;
	public bool spacePressed;
	public 

	void Update () {
		transform.position += new Vector3 ((0-speed)*Time.deltaTime,0,0);
		if (Input.GetKey (KeyCode.Space) && !spacePressed) {
			GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 400, 0));
			spacePressed = true;
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.position += new Vector3 (0, 0, (0 - speed) * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.position += new Vector3 (0, 0, speed * Time.deltaTime);
		}
	}

	void OnCollisionEnter(Collision col){
		Debug.Log (col.gameObject.name);
		if (col.gameObject.name == "Floor") {
			spacePressed = false;
		} else if (col.gameObject.transform.parent.gameObject.name == "Obstacles") {
			transform.position = new Vector3 (25, 2, 0);
		} else if (col.gameObject.name == "Fin") {
			transform.position = new Vector3 (0, 10000, 0);
		}
	}
}
