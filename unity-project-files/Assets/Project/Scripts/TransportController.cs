using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportController : MonoBehaviour
{

    AudioSource m_MyAudioSource;
    public bool m_Play;
	public bool m_togglechange;
	PlaybackHandler _PlaybackHandler;

	void Start()
	{
		_PlaybackHandler = GetComponentInParent<PlaybackHandler>();
		m_Play = _PlaybackHandler.m_play;
		m_togglechange = _PlaybackHandler.m_togglechange;
	}
	void PlayThisSound()
    {
        AudioSource thisAudioSource = GetComponentInChildren<AudioSource>();
        thisAudioSource.loop = true;
        thisAudioSource.Play();
		
    }

    void StopThisSound()
    {
        AudioSource thisAudioSource = GetComponentInChildren<AudioSource>();
        thisAudioSource.Stop();
    }

    
}
