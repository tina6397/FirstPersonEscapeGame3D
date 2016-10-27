using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DoorScript : MonoBehaviour {

    public ScoreManager scoreManager;
    //public Text text;
    public AudioSource[] audio ;
    public AudioSource doorLock;
    public AudioSource doorOpen;
    public AudioSource doorClose;
    //public AudioClip test;


    public bool playerHaveKey;
    public bool clicked = false;
    public float doorOpenAngle_Y = -90f;
    public float doorCloseAngle_Y = 0f;
    public float doorOpenAngle_Z = -90f;
    public float doorCloseAngle_Z = 0f;
    // Use this for initialization
    void Awake()
    {
        scoreManager = GetComponent<ScoreManager>();
        playerHaveKey = false;

        audio = GetComponents<AudioSource>();
        //test = GetComponent<AudioClip>();

        //doorLock = GetComponent<AudioSource>();
        //doorOpen = GetComponent<AudioSource>();
        //doorClose = GetComponent<AudioSource>();

        doorLock = audio[0];
        doorOpen = audio[1];
        doorClose = audio[2];

        //text = GetComponent<Text>();

    }




    public void OnMouseDown()
    {
        //clicked = true;
        Debug.Log("CLICK");

        //check if player have key to unlock the door
        if (playerHaveKey)
        {
            clicked = !clicked;
            doorOpen.Play();



        }
        else
        {
            Debug.Log("No Key!");
            //text.text = "Door locked. Need a key.";
            doorLock.Play();
        }

        if (clicked)
        {
            doorClose.Play();
        }

       
           // doorClose.Play();
        
        


        //Application.LoadLevel(2);
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


        if(ScoreManager.currentScore > 0)
        {
            playerHaveKey = true;
        }
    }
}
