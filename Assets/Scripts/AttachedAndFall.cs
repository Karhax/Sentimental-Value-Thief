using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachedAndFall : MonoBehaviour {

	private Vector3 pos;

	// Use this for initialization
	void Start () {
		pos = transform.position;
		transform.GetComponent<Rigidbody> ().useGravity = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (pos != transform.position) {
			transform.GetComponent<Rigidbody> ().useGravity = true;
		}
	}
}
