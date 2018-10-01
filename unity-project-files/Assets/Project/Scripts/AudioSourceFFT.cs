using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class AudioSourceFFT : MonoBehaviour
{
    AudioSource audiosrc;
    public static int resolution;
    public static int n;
    public float[] samples = new float[resolution];
    void Start()
    {
        audiosrc = GetComponent<AudioSource>();
        if (resolution == 0)
        { throw new System.ArgumentException("Warning! Resolution is set to 0. This will stop the FFT transform from working properly."); }

    }
    void GetSpectrumAudioSource()
    {
		float[] spectrum = new float[resolution];
        audiosrc.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);
		 for (int i = 1; i < spectrum.Length - 1; i++)
        {
            Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.red);
            Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.blue);
        }
    }
}
