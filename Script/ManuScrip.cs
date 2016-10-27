using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ManuScrip : MonoBehaviour {

    public Button singlePlayer;
    public Button exitGame;

	// Use this for initialization
	void Start () {
        exitGame = exitGame.GetComponent<Button> ();
        singlePlayer = singlePlayer.GetComponent<Button>();
    }
	
    public void ExitPress()
    {
        Application.Quit();

    }

    public void SinglePlayer()
    {
        Application.LoadLevel(1);

    }

	// Update is called once per frame
	void Update () {
	
	}
}
