using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundObjectFXController : MonoBehaviour {

AudioSource source;
private float scaledPanning;
private float scaledVolume;
public GameObject leftcollider;
public GameObject rightcollider;
public GameObject frontcollider;

public float minimumObjectDistanceToUser;
private float minimumPanningBoundaryValue; 
private float maximumPanningBoundaryValue; 
private float minimumVolumeBoundaryValue;
private float maximumVolumeBoundaryValue;
	void Start() {
		source = GetComponent<AudioSource>();
		frontcollider = GameObject.FindGameObjectWithTag("fcol");
		leftcollider = GameObject.FindGameObjectWithTag("lcol");
		rightcollider = GameObject.FindGameObjectWithTag("rcol");
		minimumPanningBoundaryValue = leftcollider.transform.position.x;
		maximumPanningBoundaryValue = rightcollider.transform.position.x;
		minimumVolumeBoundaryValue = minimumObjectDistanceToUser;
		maximumVolumeBoundaryValue = frontcollider.transform.position.z;
		StartCoroutine(PanningAndVolumeAdjustmentCoroutine());
		Debug.Log("SetPanningRealtimeCoroutine has been initialized.");
	}

	private IEnumerator PanningAndVolumeAdjustmentCoroutine(){
		float gameObjectXPosition = gameObject.transform.position.x;
		float gameObjectZPosition = gameObject.transform.position.z;
		scaledPanning = ScalarConversionTool(minimumPanningBoundaryValue,maximumPanningBoundaryValue,gameObjectXPosition,-1f,1f);
		scaledVolume = 1f-ScalarConversionTool(minimumVolumeBoundaryValue,maximumVolumeBoundaryValue,gameObjectZPosition,0f,1f);
		source.panStereo = scaledPanning;
		source.volume = scaledVolume;
		yield return new WaitForSeconds(.05f);
	}

	// Use this for initialization
	void UpdateFX() {
		StartCoroutine(PanningAndVolumeAdjustmentCoroutine());
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
