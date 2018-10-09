using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpectrumColorChange : MonoBehaviour
{
    private AudioSource audioSource;
    float[] spectrum = new float[1];
    private float minVolume = 0.005f;
    
    public Color color = Color.white;
	public Color colorStart = Color.green;
	public Color colorEnd = Color.red;
    private float red;
    private float green;
    private float blue;

    // Spectrum Multiplier
	Renderer rend;
    void Start()
    {
		
        audioSource = gameObject.GetComponent<AudioSource>();
		rend = GetComponent<Renderer>();
    }

    void Update()
    {
        AnalyzeMusicFromAudioSource();
        UpdateColorOfObject();
    }

    void AnalyzeMusicFromAudioSource()
    {
        if (AudioListener.volume == 0)
        {
            AudioListener.volume = minVolume;
        };

         audioSource.GetOutputData(spectrum, 0);
       
    }
    void UpdateColorOfObject()
    {
		rend.material.color = Color.Lerp(colorStart,colorEnd,spectrum[0]*10);
		new WaitForSeconds(0.1f);
    }

    public Color GetColor()
    {
        return color;
    }
}
