using UnityEngine;
using System.Collections;

public class healthAidScript : MonoBehaviour {


    int capacity = 3;
	// Use this for initialization
	void Start () {
	
	}

    public void OnMouseDown()
    {
        if (capacity > 0)
        {
            //say consumed one health pill
            capacity--;
            PlayerHealthManager.IncreaseHealth(50);
            GUIInstructionScript.changText("I feel energised...");

        }
        else
        {
            // say no more phills left
            GUIInstructionScript.changText("NO MORE PILLS LEFT! :(");

        }
    }


    // Update is called once per frame
    void Update () {
	
	}
}
