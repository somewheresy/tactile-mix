using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CleanUpOldComponents : MonoBehaviour
{
    public void DeleteAudioAndSobjects()
    {
        Debug.Log("Deleting left over audio sources...");
        // Deletes leftover AudioSource entities before creating new ones


        foreach (var audsrc in gameObject.GetComponentsInParent<AudioSource>(true))
        {
            if (audsrc)
            {
                DestroyImmediate(audsrc);
                Debug.Log("Deleting one audio source...");
            }
        }

        // Initializes an array of the SOBJ Physical Models, finds by use of tag, destroys any which were left over


        GameObject[] SoundObjectPhysicalModels = GameObject.FindGameObjectsWithTag("SoundObjectPhysical");
        if (SoundObjectPhysicalModels.Length > 0)
        {
            for (int x = 0; x < SoundObjectPhysicalModels.Length; x++)
            {
                DestroyImmediate(SoundObjectPhysicalModels[x]);
                Debug.Log("Deleted SoundObject" + x.ToString());
            }
        }
    }
}