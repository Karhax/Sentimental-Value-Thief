using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverInfo : MonoBehaviour {

    private float interactDistance = 4f;
    GameObject hoverHud;

	void Start () {
		
	}
	
	void Update () {

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * interactDistance, Color.yellow);
            if (hit.transform.gameObject.tag == "Sellable")
            {

            }
        }        
    }
}
