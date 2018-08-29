using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this checks if the cubes are put into the dropzones in the right order 
public class Watcherscript : MonoBehaviour {
    public GameObject[] cubes;
    public GameObject[] dropZones;
    public int currentCube = 0;
    public GameObject myDropzone = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShuffleCubes ()
    {

    }

    //Checks if "cube" parameter object is the correct cube in the sequence
    public void Checkerino (GameObject cube)
    {
        //return cubes[currentCube] == cube;
        Debug.Log(cube.name);
        if (cubes[currentCube] != cube)
        {
            var snapdropzone = myDropzone.GetComponent<VRTK.VRTK_SnapDropZone>();
            snapdropzone.ForceUnsnap();
        }
    }

    public void CubePut()
    {
        currentCube += 1;
    }
}
