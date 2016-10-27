using UnityEngine;
using System.Collections;

public class BoxOpenScript : MonoBehaviour {


    public bool clicked = false;
    // Use this for initialization
    void Start () {
	
	}

    public void OnMouseDown()
    {
        //clicked = true;
        clicked = !clicked;
    }

    // Update is called once per frame
    void Update () {
        if (clicked)
        {
            Quaternion targetRotation = Quaternion.Euler(-130f, 0, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, 2f * Time.deltaTime);
        }
        else
        {
            Quaternion targetRotation = Quaternion.Euler(0, 0f, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, 2f * Time.deltaTime);
        }
    }
}
