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
	public Canvas canvas;
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
			Camera.main.enabled = false;
		}
		if (transform.childCount > 0 && endGame) {
			transform.GetChild (0).GetComponent<MeshRenderer> ().enabled = true;
			valueCurrent = transform.GetChild (0).GetComponent<ValueScript> ().value;
			timeDisplayTemp -= Time.deltaTime;
			if (timeDisplayTemp < 0) {
				timeDisplayTemp = timeDisplay;
				GameObject.Destroy (transform.GetChild (0).gameObject);
				valueOverall += valueCurrent;
				print (valueOverall.ToString ());
				valueCurrent = 0f;
			}
		} else if (transform.childCount == 0 && endGame) {
			
		}
	}
}
