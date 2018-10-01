using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollisionHandler : MonoBehaviour
{
    public GameObject FrontCollide;
    public GameObject LeftCollide;
    public GameObject RightCollide;
	public float DepthAdjustment;
    public float WidthAdjustment;
	public float HeightAdjustment;


    public void SetBounds()
    {
        FrontCollide = GameObject.FindGameObjectWithTag("fcol");
        LeftCollide = GameObject.FindGameObjectWithTag("lcol");
        RightCollide = GameObject.FindGameObjectWithTag("rcol");
        GameObject objmgr = GameObject.FindWithTag("Sound Object System");
        GenerateSpeakers generateSpeakers;
        generateSpeakers = objmgr.GetComponent<GenerateSpeakers>();
        transform.position = new Vector3(0f, generateSpeakers.userHeight, 0f);
        transform.localScale = new Vector3(generateSpeakers.distanceBetweenSpeakers + WidthAdjustment, 1f + HeightAdjustment, 1f + DepthAdjustment);
    }
    void Awake()
    {
        SetBounds();
        print("The boundaries for the stereo field have been set.");
    }
}
