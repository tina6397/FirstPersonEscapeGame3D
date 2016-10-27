using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GUI_sttacked_fadein_out : MonoBehaviour {

    public static  Image black;

    // Use this for initialization
    void Start () {
        black = GetComponent<Image>();
        black.enabled = true;
        //black.color = Color.clear;
    }
	
	// Update is called once per frame
	void Update () {
        black.color = Color.Lerp(black.color, Color.clear, 0.3f * Time.deltaTime);
        //black.color = Color.Lerp( Color.white, Color.black, 0.3f * Time.deltaTime);

    }

    public static void changeColor()
    {
        black.color = Color.red;
    }
}
