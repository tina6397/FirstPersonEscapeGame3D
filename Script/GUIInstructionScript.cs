using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GUIInstructionScript : MonoBehaviour {
    public static Text textHealth;

    // Use this for initialization
    void Start () {
        textHealth = GetComponent<Text>();
        textHealth.enabled = true;

    }

    // Update is called once per frame
    void Update () {
        Fade();
        textHealth.color = Color.Lerp(textHealth.color, Color.clear, 0.3f * Time.deltaTime);

    }
    public void Fade()
    {

    }

    public static void changText(string s) {
        textHealth.color = Color.white;
        textHealth.enabled = true;
        textHealth.text = s;
        //textHealth.enabled = false;

        //delay the method for 2s before game over



    }

}
