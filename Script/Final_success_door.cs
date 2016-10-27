using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Final_success_door : MonoBehaviour {

	  // Use this for initialization
    void Start()
    {

    }

    void OnMouseDown()
    {
        Cursor.lockState = CursorLockMode.None;

        //Application.LoadLevel(3);
        SceneManager.LoadScene(3);

    }
    // Update is called once per frame
    void Update()
    {

    }
}
