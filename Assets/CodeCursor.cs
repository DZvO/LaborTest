using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeCursor : MonoBehaviour {
    int direction = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position += new Vector3(0, 0.75f * direction * 0.001f, 0);
        if (Mathf.Abs(this.transform.position.y) >= 4.0) direction *= -1;
	}
}
