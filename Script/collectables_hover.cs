using UnityEngine;
using System.Collections;

public class collectables_hover : MonoBehaviour {
    public GUIStyle hoverIcon;
    Transform player;
    bool mouseOver = false;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnMouseOver()
    {

        //change icon
        if (Vector3.Distance(transform.position, player.position)<40)
        {
            mouseOver = true;

        }
    }

    public void OnMouseExit()
    {
        Debug.Log("hover exit");
        //change icon
        mouseOver = false;
    }

    void OnGUI()
    {
        if (mouseOver)
        {
            GUI.Box(new Rect(Screen.width / 2 - 40, Screen.height / 2 -40 , 80, 80), "", hoverIcon);

        }
    }
}
