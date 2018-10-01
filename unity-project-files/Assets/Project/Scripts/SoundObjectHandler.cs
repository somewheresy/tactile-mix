using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Leap;
using InteractionEngineUtility;


// Shows the assignments and parameters in the editor and executes it in Edit Mode

public class SoundObjectHandler : MonoBehaviour
{
    // show these in editor to make sure that they aren't acting screwy
    private float distanceBetweenSpeakers;
    public float userHeight = 1.0f;
    private float monitorHeightOffset;
    public GameObject SoundObject;
    public GameObject[] SoundObjectPhysicalModels;
    private Transform Center;
    public Transform ColliderForward;
    public Sound[] sounds;
    public AudioMixerGroup MasterMixer;
    public static SoundObjectHandler instance;
    private GenerateSpeakers speakerGenerator;
    public float pi = 3.1415f;
    private AudioClip[] resourceAudioClips;

    // useful tools I may have to use later
    
    void Awake()
    {
        LoadAudioFiles();
        StartCoroutine(LoadSoundObjects());
    }
        private void LoadAudioFiles()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        Debug.Log("Loading audio files from path: Resources/AudioFiles/...");
        resourceAudioClips = Resources.LoadAll<AudioClip>("AudioFiles");
        Array.Resize(ref sounds, resourceAudioClips.Length); 
        Debug.Log(resourceAudioClips.Length.ToString() + "<color=green> audio files successfully loaded.</color>");
        
    }

    // Generates SoundObjects based on the loaded files
    private IEnumerator LoadSoundObjects()
    {
        Debug.Log("<color=yellow>Generating SoundObjects...</color>");
        speakerGenerator = GetComponent<GenerateSpeakers>();
        distanceBetweenSpeakers = speakerGenerator.distanceBetweenSpeakers;
        float offset = distanceBetweenSpeakers / resourceAudioClips.Length;
        for (int n = 0; n < resourceAudioClips.Length; n++)
        {
            float pos = -0.5f * distanceBetweenSpeakers + offset * n;

            GameObject go = Instantiate(SoundObject, new Vector3(pos, userHeight, 0), Quaternion.identity)
            as GameObject;
            go.transform.parent = gameObject.transform;
        }
        
        SoundObjectPhysicalModels = GameObject.FindGameObjectsWithTag("SoundObjectPhysical");
        
        Debug.Log("<color=green>SoundObjects physical attributes have been generated.</color>");
        Debug.Log("<color=yellow>Assigning audio files to SoundObjects...</color>");

        for (int x = 0; x < SoundObjectPhysicalModels.Length; x++)
        {
            SoundObjectPhysicalModels[x].name = resourceAudioClips[x].name;
            sounds[x].source = SoundObjectPhysicalModels[x].AddComponent<AudioSource>();
            sounds[x].source.outputAudioMixerGroup = MasterMixer;
            sounds[x].clip = resourceAudioClips[x];
            sounds[x].source.clip = sounds[x].clip;
            sounds[x].source.panStereo = sounds[x].panStereo;
            sounds[x].source.loop = sounds[x].loop;
            sounds[x].transform = SoundObjectPhysicalModels[x].transform;
            Debug.Log(SoundObjectPhysicalModels[x].name + "<color=green> has been assigned the Audio Clip </color>" + resourceAudioClips[x].name + ".");
        }

        yield return new WaitForSeconds( 1 );

        Debug.Log("<color=green>All SoundObjects initialized.</color>");
        Debug.Log("<color=yellow>The Panning and Volume controls are updated whenever the object is moved.</color>");
    }
}


