using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverInfo : MonoBehaviour {

    private float interactDistance = 4f;
    public GameObject hoverHud;
    public LayerMask layerMask;

    private Text hoverItemName;
    private Text hoverItemDesc;
	
	void Update () {

        Debug.DrawRay(transform.position, transform.forward * interactDistance, Color.yellow);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactDistance, layerMask))
        {
            if (hit.collider.gameObject.tag == "Sellable")
            {                
                var hitObject = hit.transform.GetComponent<ValueScript>();
                hoverHud.SetActive(true);
                hoverItemName = hoverHud.transform.GetChild(0).GetComponentInChildren<Text>();
                hoverItemDesc = hoverHud.transform.GetChild(1).GetComponentInChildren<Text>();
                hoverItemName.text = hitObject.value.ToString();
                hoverItemDesc.text = '"' + hitObject.description.ToString() + '"';
            }
            else
            {
                hoverHud.SetActive(false);
            }
        }
        else
        {
            hoverHud.SetActive(false);
        }
    }
}
