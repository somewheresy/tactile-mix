using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHeadsetPos : MonoBehaviour {
	void Start () {
		GameObject objmgr = GameObject.FindWithTag("Sound Object System");
		GenerateSpeakers generateSpeakers;
		generateSpeakers = objmgr.GetComponent<GenerateSpeakers>();
		transform.position = new Vector3(0.0f,generateSpeakers.userHeight,-generateSpeakers.distanceToSpeakers);
	}
}
