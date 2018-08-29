using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

//this checks if the cubes are put into the dropzones in the right order 
public class Watcherscript : MonoBehaviour {
    public GameObject[] cubes;
    public GameObject[] dropZones;
    public int currentCube = 0;
    public GameObject myDropzone = null;

	// Use this for initialization
	void Start () {
        foreach (var dropzone in dropZones)
        {
            var snapdropzone_unity_events = dropzone.GetComponent<VRTK.UnityEventHelper.VRTK_SnapDropZone_UnityEvents>();

            snapdropzone_unity_events.OnObjectEnteredSnapDropZone.AddListener(EnteringSnap);
            snapdropzone_unity_events.OnObjectExitedSnapDropZone.AddListener(LeavingSnap);
            //snapdropzone_unity_events.OnObjectSnappedToDropZone.AddListener(Checkerino);
            snapdropzone_unity_events.OnObjectSnappedToDropZone.AddListener(SnappedToDropZone);
        }
	}

    private void SnappedToDropZone(object arg0, SnapDropZoneEventArgs arg1)
    {
        currentCube++;
    }

    private void LeavingSnap(object arg0, SnapDropZoneEventArgs arg1)
    {
        ((VRTK_SnapDropZone)arg0).highlightColor = Color.yellow;
        ((VRTK_SnapDropZone)arg0).validHighlightColor = Color.yellow;
        ((VRTK_SnapDropZone)arg0).enableSnapping = true;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void ShuffleCubes () {

    }

    //TODO Should probably extend "VRTK_Policy List" insted?
    private void EnteringSnap(object arg0, SnapDropZoneEventArgs arg1) {
        Debug.Log(DateTime.Now.ToString());
        var snapObj = arg1.snappedObject;
        VRTK.VRTK_SnapDropZone snapZone = (VRTK_SnapDropZone)arg0;
        // Debug.Log(cube.name);
        Debug.Log("Checking if in correct order for: snapObj = " + snapObj.name + ", snapZone = " + snapZone.gameObject.name + ", --- currentCube = " + currentCube);

        if (cubes[currentCube] == snapObj && dropZones[currentCube] == snapZone.gameObject)
        {
            Debug.Log("In correct order!");
        }
        else
        {
            snapZone.highlightColor = Color.red;
            snapZone.validHighlightColor = Color.red;
            snapZone.enableSnapping = false;
            Debug.Log("Not in correct order!");
        }
        Debug.Log("");
    }

    public void CubePut() {
        currentCube += 1;
    }
}
