using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class ToggleWrapper : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void Toggle(GameObject toToggleGameObject)
    {
        Debug.Log("Toggling " + toToggleGameObject.name + " (" + toToggleGameObject.activeSelf + " -> " + !toToggleGameObject.activeSelf + ")");
        toToggleGameObject.SetActive(!toToggleGameObject.activeSelf);

    }
}
