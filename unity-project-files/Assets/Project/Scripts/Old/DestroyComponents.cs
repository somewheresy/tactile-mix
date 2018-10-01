using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[ExecuteInEditMode]
public class DestroyComponents : MonoBehaviour{
public Transform GameObject;
void Awake(){
		    var components = this.GameObject.GetComponents(typeof(Component));
     
        for (int n = 0; n < components.Length; n++){
                     DestroyImmediate(components[n]);
        }
	}
}
