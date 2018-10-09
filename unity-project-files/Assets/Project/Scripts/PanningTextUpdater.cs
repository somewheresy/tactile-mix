using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanningTextUpdater : MonoBehaviour {

AudioSource soundObjectSource;
private string displayText;
public string PanningCalculation;

// For future reference, Unity's panning uses constant-power panning using square root of intensity where at (0.0) the panning is 71% L and 71% R. This allows for audibly smoother panning.
TextMesh textMesh;
MeshRenderer meshRenderer;
	void Start () {
		textMesh = gameObject.GetComponent<TextMesh>();
		meshRenderer = gameObject.GetComponent<MeshRenderer>();
		soundObjectSource = gameObject.GetComponentInParent<AudioSource>();
		DisableText();
		StartCoroutine(UpdatePanningDisplayCoroutine());
	}
	public IEnumerator UpdatePanningDisplayCoroutine () {

		if (Mathf.Round(soundObjectSource.panStereo*50) > 0)
		{
		displayText = "pan: " + Mathf.Round(soundObjectSource.panStereo*100 + 4f) + "% R";
		}
		else if (Mathf.Round(soundObjectSource.panStereo*50) < 0)
		{
		displayText = "pan: " + -Mathf.Round(soundObjectSource.panStereo*100 - 4f) + "% L";
		}
		else if (Mathf.Round(soundObjectSource.panStereo*50) == 0)
		{
		displayText = "pan: Center";
		}
		else
		{
		displayText = "ERROR";
		}
		textMesh.text = displayText;
		yield return null;
	}

	void UpdatePanningDisplay(){
		StartCoroutine(UpdatePanningDisplayCoroutine());
	}

	void EnableText(){
		meshRenderer.enabled = true;
	}

	void DisableText(){
		meshRenderer.enabled = false;
	}
	float ScalarConversionTool(float min, float max, float x, float a, float b){
			if (max-min != 0){
			x = (((b-a)*(x-min))/(max-min))+a;
			return x;
			}
			else
			{
			Debug.LogError("WARNING: Divide by zero error -- see variables " + min + " and " + max);
			return 0;
			}
	}
}
