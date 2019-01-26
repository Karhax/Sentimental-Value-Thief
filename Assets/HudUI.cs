using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudUI : MonoBehaviour
{

	public Text overallValue;
	public Text currentValue;
	public RawImage crosshair;
	public Text gameOverText;
	private float defaultY;
	private float defaultX;

	// Use this for initialization
	void Start ()
	{
		currentValue.enabled = false;
		overallValue.enabled = false;
		gameOverText.enabled = false;
		defaultY = currentValue.rectTransform.localPosition.y;
		defaultX = currentValue.rectTransform.localPosition.x;
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	public void ResetCurrentValuePosition ()
	{
		currentValue.rectTransform.localPosition = new Vector3 (defaultX, defaultY, 0f);
	}

	public void SetOverallValue (float value)
	{
		overallValue.text = value.ToString ();
		gameOverText.text = "Congratulations, you made " + value.ToString () + "$ for the devil. Press space to try again";
	}

	public void SetCurrentValue (float value)
	{
		currentValue.text = value.ToString ();
	}

	public void EndGame ()
	{
		crosshair.enabled = false;
		currentValue.enabled = true;
		overallValue.enabled = true;
	}
	public void GameOver()
	{
		currentValue.enabled = false;
		overallValue.enabled = false;
		gameOverText.enabled = true;
	}
}
