using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

//this is the global watch script that handles all business logic, for example this sets up the world and attaches the pointers to the blocks
// TODO am anfang die blöcke schon in snapzones stecken (das array) bei welchem die cubes zurück snappen. swappen überlegen.        
public class Watcherscript : MonoBehaviour {
    public GameObject[] cubes;
    public GameObject[] dropZones;
    public int currentCube = 0;
    public GameObject myDropzone = null;
    public GameObject pointer_n = null;
    public GameObject pointer_newn = null;

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

        pointer_newn.transform.SetParent(cubes[0].transform);
        //pointer_newn.transform.position = cubes[0].transform.position;
        pointer_n.transform.SetParent(cubes[cubes.Length - 1].transform);
        //pointer_n.transform.position = cubes[cubes.Length - 1].transform.position + (new Vector3(0.0f, 0.15f, 0.0f));

        pointer_n.transform.localPosition = new Vector3(0.0f, 0.6f, 0.0f) + new Vector3(0.0f, cubes[cubes.Length - 1].transform.localScale.y, 0.0f) * 1;
        pointer_newn.transform.localPosition = new Vector3(0.0f, 0.6f, 0.0f) + new Vector3(0.0f, cubes[0].transform.localScale.y, 0.0f) * 1;
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

    //TODO instead of "N" should probably get an index so we can manage multiple pointers more easily
    public void SetPointerN()
    {

    }
}
