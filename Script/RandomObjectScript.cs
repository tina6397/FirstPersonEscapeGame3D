using UnityEngine;
using System.Collections;

public class RandomObjectScript : MonoBehaviour {

	// Use this for initialization

        public Vector3[] positions;

	void Awake () {


        int randomeNumber = Random.Range(0, positions.Length);
        transform.position = positions[randomeNumber];

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
