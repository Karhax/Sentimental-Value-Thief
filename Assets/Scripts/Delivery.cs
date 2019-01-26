using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour {
	
	public float collected = 0f;
	public GameObject gatherer;
	
	void Update () {
		
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Sellable");
		{
			collected += other.gameObject.GetComponent<ValueScript> ().value;
			other.gameObject.GetComponent<Rigidbody> ().isKinematic = true;
			other.gameObject.transform.SetParent (gatherer.transform);
			other.gameObject.transform.localPosition = Vector3.zero;
			other.gameObject.GetComponent<MeshRenderer> ().enabled = false;
		}
	}

}