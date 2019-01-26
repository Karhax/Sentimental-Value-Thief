using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameOver : MonoBehaviour
{

	public float timeLeft = 5f;
	public float timeDisplay = 5f;
	private float timeDisplayTemp;
	private float valueOverall;
	private float valueCurrent;
	public HudUI hudUI;
	private bool endGame = false;
	// Use this for initialization
	void Start ()
	{
		timeDisplayTemp = timeDisplay;
	}

	// Update is called once per frame
	void Update ()
	{
		transform.localPosition = new Vector3 (0f, Mathf.Sin (Time.time) * 0.2f, 0f);
		transform.localEulerAngles += new Vector3 (0f, 0.8f, 0.5f);
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0f && !endGame) {
			endGame = true;
			print ("gameover");
			hudUI.EndGame ();
			Camera.main.enabled = false;
		}
		if (transform.childCount > 0 && endGame) {
			transform.GetChild (0).GetComponent<MeshRenderer> ().enabled = true;
			valueCurrent = transform.GetChild (0).GetComponent<ValueScript> ().value;
			timeDisplayTemp -= Time.deltaTime;
			hudUI.currentValue.rectTransform.localPosition = Vector3.Lerp (hudUI.currentValue.rectTransform.localPosition, hudUI.overallValue.rectTransform.localPosition, 0.5f*Time.deltaTime);
			if (timeDisplayTemp < 0) {
				timeDisplayTemp = timeDisplay;
				GameObject.Destroy (transform.GetChild (0).gameObject);
				valueOverall += valueCurrent;
				valueCurrent = 0f;
				hudUI.ResetCurrentValuePosition ();
			}
		} else if (transform.childCount == 0 && endGame) {
			
		}
		UpdateValues ();
	}

	void UpdateValues ()
	{
		hudUI.SetCurrentValue (valueCurrent);
		hudUI.SetOverallValue (valueOverall);
	}
}
