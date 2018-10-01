using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObjectName : MonoBehaviour {

public TextMesh textMesh;
public string objectName;
	// Use this for initialization
	void Start () {
		objectName = this.gameObject.name;
		textMesh.text = objectName;
	}
}
