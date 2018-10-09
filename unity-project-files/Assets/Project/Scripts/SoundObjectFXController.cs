using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundObjectFXController : MonoBehaviour {

AudioSource source;
private float scaledPanning;
private float scaledVolume;

public Collider thisCollider;
public ColliderDistance2D distanceToCollider;
public GameObject leftcollider;
public GameObject rightcollider;
public GameObject frontcollider;

public float minimumObjectDistanceToUser;
public float minimumPanningBoundaryValue; 
public float maximumPanningBoundaryValue; 
public float minimumVolumeBoundaryValue;
public float maximumVolumeBoundaryValue;
Vector3 closestSurfacePoint1;
Vector3 closestSurfacePoint2;
	void Start() {
		source = GetComponent<AudioSource>();
		frontcollider = GameObject.FindGameObjectWithTag("fcol");
		leftcollider = GameObject.FindGameObjectWithTag("lcol");
		rightcollider = GameObject.FindGameObjectWithTag("rcol");
		
		minimumObjectDistanceToUser = 0.1f;
		minimumPanningBoundaryValue = leftcollider.transform.position.x;
		maximumPanningBoundaryValue = rightcollider.transform.position.x;
		minimumVolumeBoundaryValue = minimumObjectDistanceToUser; 
		maximumVolumeBoundaryValue = frontcollider.transform.position.z;
		StartCoroutine(PanningAdjustmentCoroutine());
		Debug.Log("PanningAdjustmentCoroutine has been initialized.");
		StartCoroutine(VolumeAdjustmentCoroutine());
		Debug.Log("VolumeAdjustmentCoroutine has been initialized.");
	}

	private IEnumerator PanningAdjustmentCoroutine(){
		float gameObjectXPosition = gameObject.transform.position.x;
		scaledPanning = ScalarConversionTool(minimumPanningBoundaryValue,maximumPanningBoundaryValue,gameObjectXPosition,-1f,1f);
		source.panStereo = scaledPanning;
		yield return null;
		
	}

	private IEnumerator VolumeAdjustmentCoroutine(){
		closestSurfacePoint1 = thisCollider.ClosestPointOnBounds(frontcollider.transform.position);
		closestSurfacePoint2 = frontcollider.GetComponent<Collider>().ClosestPointOnBounds(thisCollider.transform.position);
		float surfaceDistance = Vector3.Distance(closestSurfacePoint1, closestSurfacePoint2);
		scaledVolume = ScalarConversionTool(minimumVolumeBoundaryValue,maximumVolumeBoundaryValue,surfaceDistance,0f,1f);
		source.volume = scaledVolume;
		yield return null;
	}

	// Use this for initialization
	void UpdateFX() {
		StartCoroutine(PanningAdjustmentCoroutine());
		StartCoroutine(VolumeAdjustmentCoroutine());
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
