using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Audio;
using Leap;
using InteractionEngineUtility;

public class PlaybackHandler : MonoBehaviour
{
    // Playing an audiofile by string with PlayFromString()
    [SerializeField]
    private GameObject ObjectManager;
    private SoundObjectHandler soundObjectHandler;
    private Sound[] sounds;
    private AudioClip[] resourceAudioClips;
    private AudioSource audioSource;
    public bool m_togglechange;
    public bool m_play;
    void Update()
    {
        //Check to see if you just set the toggle to positive
        if (m_play == true && m_togglechange == true)
        {
            //Play the audio you attach to the AudioSource component
            gameObject.BroadcastMessage("PlayThisSound");
            Debug.Log("Broadcasted <color=green>PLAY</color> message to all sounds.");
            m_togglechange = false;

        }
        //Check if you just set the toggle to false
        if (m_play == false && m_togglechange == true)
        {
            //Stop the audio
            gameObject.BroadcastMessage("StopThisSound");
            print("Broadcasted <color=red>STOP</color> message to all sounds.");
            m_togglechange = false;
        }
    }

}
