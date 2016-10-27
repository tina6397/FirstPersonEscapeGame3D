using UnityEngine;
using System.Collections;

public class doorNoKeyScript : MonoBehaviour {

    public bool clicked = false;
    public float doorOpenAngle_Y = -90f;
    public float doorCloseAngle_Y = 0f;
    public float doorOpenAngle_Z = -90f;
    public float doorCloseAngle_Z = 0f;
    // Use this for initialization

    public AudioSource audio;
    void Awake()
    {
        audio = GetComponent<AudioSource>();
    }




    public void OnMouseDown()
    {
        //clicked = true;
        Debug.Log("CLICK");
        clicked = !clicked;

        if (clicked)
        {
            PlayAudio();
        }
        else
        {
            Invoke("PlayAudio", 2);
        }

        //Application.LoadLevel(2);
    }

    void PlayAudio()
    {
        audio.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if (clicked)
        {
            Quaternion targetRotation = Quaternion.Euler(0, doorOpenAngle_Y, doorOpenAngle_Z);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, 2f * Time.deltaTime);
        }
        else
        {
            Quaternion targetRotation = Quaternion.Euler(0, doorCloseAngle_Y, doorCloseAngle_Z);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, 2f * Time.deltaTime);
        }


    }
}
