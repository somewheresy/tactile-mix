using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class VolumeTextUpdater : MonoBehaviour {

TextMesh textMesh;
MeshRenderer meshRenderer;
AudioSource soundObjectSource;
	// This script is written with conversion values for a sample rate of 48 kHz and 24 bit depth
	void Start () {
		textMesh = gameObject.GetComponent<TextMesh>();
		meshRenderer = gameObject.GetComponent<MeshRenderer>();
		soundObjectSource = gameObject.GetComponentInParent<AudioSource>();
		DisableText();
		StartCoroutine(UpdateVolumeTextCoroutine());
	}

	public IEnumerator UpdateVolumeTextCoroutine(){
		// Rounds to one decimal place
		textMesh.text = "vol: " + (Mathf.Round(LinearToDB(soundObjectSource.volume)*10)/10.0) + " dB";
		yield return null;
	}
	void UpdateVolumeDisplay(){
		StartCoroutine(UpdateVolumeTextCoroutine());
	}

	void EnableText(){
		meshRenderer.enabled = true;
	}

	void DisableText(){
		meshRenderer.enabled = false;
	}
	public float LinearToDB(float linear)
    {
        float dB;
        if (linear != 0)
            dB = 20.0f * Mathf.Log10(linear);
        else
            dB = -144.0f;
        return dB;
    }
}
