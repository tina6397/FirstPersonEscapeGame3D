using UnityEngine;
using System.Collections;

public class musicTriggerScript : MonoBehaviour {

    public AudioSource audio;
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER"+other.name);
        audio.Play();
        audio.loop = false;

    }

    //void OnTriggerExit(Collider other)
    //{
      
    //    audio.Stop();
    //}
 }
