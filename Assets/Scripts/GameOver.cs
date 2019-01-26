using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

	public float timeLeft = 5f;
	public float timeDisplay = 5f;
	private float timeDisplayTemp;
	private float valueOverall;
	private float valueCurrent;
	public HudUI hudUI;
	private bool endGame = false;
	private string scene;

	void Start ()
	{
		timeDisplayTemp = timeDisplay;
	}

	void Update ()
	{
        transform.localPosition = new Vector3(0f, Mathf.Sin(Time.time) * 0.2f, 0f);
        transform.localEulerAngles += new Vector3(0f, 0.8f, 0.5f);
        timeLeft -= Time.deltaTime;
		if (timeLeft <= 0f && !endGame) {
			endGame = true;
			hudUI.EndGame ();
			Camera.main.enabled = false;
			transform.parent.Find ("Camera").gameObject.SetActive (true);
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
			hudUI.GameOver ();
			if (Input.GetKeyDown (KeyCode.Space)) {
				scene = SceneManager.GetActiveScene ().name;
				SceneManager.LoadScene (scene, LoadSceneMode.Single);
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
		}
		UpdateValues ();
	}

	void UpdateValues ()
	{
		hudUI.SetCurrentValue (valueCurrent);
		hudUI.SetOverallValue (valueOverall);
	}
}
