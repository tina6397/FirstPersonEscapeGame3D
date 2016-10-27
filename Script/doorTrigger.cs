using UnityEngine;
using System.Collections;

public class doorTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collided with " + other.gameObject.name);

    }

    void OnTriggerStay(Collider other)
    {
        //Debug.Log("TRIGGER " + other.gameObject.name);

    }

    // Update is called once per frame
    void Update () {
	
	}
}
