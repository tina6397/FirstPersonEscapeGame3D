using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseScreenScript : MonoBehaviour {

    // Use this for initialization
    //public GameObject pausePanel;
    public  CanvasGroup pauseCanvas;
    
    public  bool isPaused = false;

	void Start () {
        //pausePanel = GetComponent<GameObject>();
        pauseCanvas = GetComponent<CanvasGroup>();
        pauseCanvas.alpha = 0;
        //pausePanel.SetActive(false);
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            //Application.Quit();
            //PauseGame();
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            PauseGame();
        }
        else
        {
            UnPauseGame();
        }

       

        
    }

    void PauseGame()
    {
        //pausePanel.SetActive(true);
        pauseCanvas.alpha = 1;
        //pause
        Time.timeScale = 0.0f;
    }

    public  void UnPauseGame()
    {
        pauseCanvas.alpha = 0;

        Time.timeScale = 1.0f;
        //pausePanel.SetActive(false);
    }

    public  void Quit()
    {
        Application.Quit();
    }

    public void resume()
    {
        isPaused = false;
    }
}
