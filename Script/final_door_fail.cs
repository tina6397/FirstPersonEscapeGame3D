using UnityEngine;
using System.Collections;

public class final_door_fail : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
    void OnMouseDown()
    {
        Cursor.lockState = CursorLockMode.None;

        Application.LoadLevel(2);

    }
    // Update is called once per frame
    void Update () {
	
	}
}
