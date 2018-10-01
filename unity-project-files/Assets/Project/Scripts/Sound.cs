using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound {
	public Transform transform;
	public string name;
	public AudioClip clip;
	[Range(0f,1f)]
	public float volume;
	[Range(-1f,1f)]
	public float panStereo;
	public AudioSource source;
	public bool loop;
}
