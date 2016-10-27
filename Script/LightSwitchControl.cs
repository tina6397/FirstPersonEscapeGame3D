using UnityEngine;
using System.Collections;

public class LightSwitchControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnMouseDown()
    {
        lightSwitch.switchLight();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
