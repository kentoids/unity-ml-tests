using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplier : MonoBehaviour {

	public GameObject obj;
	public int height = 0, width = 0, depth = 0;
	float interval = 0.05f;
	void Start () {
		for (int i = 0; i < height; i++) {
			for (int j = 0; j < width; j++) {
				for (int k = 0; k < depth; k++) {
					GameObject.Instantiate(obj, transform.position + new Vector3(i * interval, j * interval, k * interval), transform.rotation);
				}
			}
		}
		GameObject.Destroy(obj);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
