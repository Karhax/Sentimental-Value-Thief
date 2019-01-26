using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachedAndFall : MonoBehaviour {

	private Vector3 pos;

	void Start () {
		pos = transform.position;
		transform.GetComponent<Rigidbody> ().useGravity = false;
	}
	
	void Update () {
		if (pos != transform.position) {
			transform.GetComponent<Rigidbody> ().useGravity = true;
		}
	}
}
