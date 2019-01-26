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

	void Start ()
	{
		currentValue.enabled = false;
		overallValue.enabled = false;
		gameOverText.enabled = false;
		defaultY = currentValue.rectTransform.localPosition.y;
		defaultX = currentValue.rectTransform.localPosition.x;
	}

	public void ResetCurrentValuePosition ()
	{
		currentValue.rectTransform.localPosition = new Vector3 (defaultX, defaultY, 0f);
	}

	public void SetOverallValue (float value)
	{
		overallValue.text = value.ToString ();
        if (value <= 0)
        {
            gameOverText.text = "You're not a very good thief, you stole nothing and obviously made " + value.ToString() + "$... Press 'Space' to play again or 'Escape' to quit the game.";
        }
        else
        {
            gameOverText.text = "Well done, you made " + value.ToString() + "$ for the devil. Press 'Space' to play again or 'Escape' to quit the game.";
        }		
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
