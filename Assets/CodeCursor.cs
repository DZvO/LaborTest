using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeCursor : MonoBehaviour {
    int direction = 1;
    float lastTick = 0;
    public Sprite [] tex;
    int index = 1;
    public Watcherscript watcher;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void Step(int index)
    {
        this.index = index;
        if (this.index >= tex.Length) this.index = 1;
        //Debug.Log("attempting to load: " + "Images/bubblesort" + (this.index.ToString()));
        Texture texture = Resources.Load("Images/bubblesort" + (this.index.ToString())) as Texture;
        //Debug.Log(texture.name);
        this.gameObject.GetComponent<Renderer>().materials[0].mainTexture = texture;
    }

    public void StepForward()
    {
        Step(index + 1);
    }
}
