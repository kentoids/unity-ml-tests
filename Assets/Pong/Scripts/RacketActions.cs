using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketActions : MonoBehaviour {

	Vector3 originalPos;
	// public Rigidbody racket;
	public GameObject myPong;
	public float posUp = 0.1f;
	public float velUp = 0.3f;
	// Use this for initialization
	void Start () {
		originalPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("space")) {
			// Vector3 pos = transform.position;
			// pos.y += upSize;
			// transform.position = pos;
			Rigidbody r = gameObject.GetComponent<Rigidbody>();
			// r.AddForce(0, posUp, 0);
			// r.velocity = new Vector3(0, posUp, 0);
			r.position += new Vector3(0, posUp, 0);
			// racket.AddForce(0, upSize, 0);
		} else {
			// checkPosition();
		}
	}

	void checkPosition() {
		if (originalPos == transform.position) return;
		if (Vector3.Distance(originalPos, transform.position) > 0.1f) {
			Vector3 to = originalPos - transform.position;
			print(to.magnitude);
			to.Normalize();
			to *= 0.05f;
			transform.position += to;
		} else {
			transform.position = originalPos;
		}
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject == myPong) {
			Rigidbody r = myPong.GetComponent<Rigidbody>();
			// r.AddForce(0, -velUp, 0);
			r.velocity = new Vector3(r.velocity.x, r.velocity.y + velUp, r.velocity.z);
			// print(Time.frameCount + ": " + r.velocity);
		}
	}
}
