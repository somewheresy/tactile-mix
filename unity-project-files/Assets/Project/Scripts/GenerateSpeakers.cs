using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSpeakers : MonoBehaviour {
public Transform Monitor;
public Transform Center;
public float distanceToSpeakers;
public float distanceBetweenSpeakers;
public float userHeight = 1.0f;
static float heightAdjustment = 0.0f;
private float monitorHeightOffset; 

int nSpeakers = 2;
	void Awake () {
		Instantiate(Center, new Vector3(0, userHeight, 0), Quaternion.identity);
		monitorHeightOffset = userHeight + heightAdjustment;
		for (int y = 0; y < nSpeakers; y++) {
			for (int x = 0; x < nSpeakers; x++){
				if (x == 0){
			Instantiate(Monitor, new Vector3(distanceBetweenSpeakers/2, monitorHeightOffset, distanceToSpeakers), Quaternion.identity);
				}
				else if (x == 1){
			Instantiate(Monitor, new Vector3(-distanceBetweenSpeakers/2, monitorHeightOffset, distanceToSpeakers), Quaternion.identity);
				}
			}
			
		}
	}

}
