using UnityEngine;
using System.Collections;

public class mouseHoverGlow : MonoBehaviour {

    public Color originalColor;
    public bool isHover = false;
	// Use this for initialization
	void Start () {

        originalColor = transform.GetComponent<Renderer>().material.color;

    }

    public void OnMouseEnter()
    {
        // transform.renderer.material.shader = Shader.Find("Self-Illuminated Diffuse");
        //renderer.material.color = Color.red;

        isHover = true;
        Debug.Log("HOVERED");

    }

    public void OnMouseExit()
    {
        isHover = false;
    }

    // Update is called once per frame
    void Update () {
	
        if (isHover)
        {
            transform.GetComponent<Renderer>().material.color = Color.white;
            //gameObject.GetComponent<Renderer>().material.color = Color.black;

        }
        else
        {
            transform.GetComponent<Renderer>().material.color = originalColor;
        }
    }
}
