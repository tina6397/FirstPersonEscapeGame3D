using UnityEngine;
using System.Collections;

public class lightSwitch : MonoBehaviour {
    public static Light light;
    public GameObject[] incorrectCodes;

	// Use this for initialization
	void Start () {
        light = GetComponent<Light>();
        incorrectCodes = GameObject.FindGameObjectsWithTag("codeIncorrect");
    }

    public static void switchLight()
    {
        if (light.enabled)
        {
            light.enabled = false;

        }
        else
        {
            light.enabled = true;

        }
    }
	
	// Update is called once per frame
	void Update () {
        if (!light.enabled)
        {
            //hide all incorrect code on the wall
            foreach (GameObject g in incorrectCodes)
            {
                g.GetComponent<Renderer>().enabled = false;
                //g.GetComponent<TextMesh>().color = Color.black;
            }


        }

    }
}
