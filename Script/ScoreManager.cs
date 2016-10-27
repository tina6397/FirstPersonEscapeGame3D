using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public static int currentScore=0;
    public bool playerDead;
    public Text textScore;
    //public CanvasGroup gameOver;

    void Start()
    {
        textScore = GetComponent<Text>();

        //gameOver = GetComponent<CanvasGroup>();
        playerDead = false;

        //gameOver.alpha = 0f;
    }

    public static void DecreaseScore()
    {
        System.Threading.Timer timer = null;
        timer = new System.Threading.Timer((obj) =>
        {

            timer.Dispose();
            currentScore--;
            Debug.Log("DECREASE SCORE");
            //DISABLE CAMERA AND BLUR VISION FOR 2 seconds

        },
                    null, 2000, System.Threading.Timeout.Infinite);


    }

    public static void IncreaseScore()
    {
        currentScore++;
    }

    public void OnGUI()
    {
    }
    
	// Update is called once per frame
	void Update () {

        if (!playerDead)
        {
            //display score if keys >= 0. else, game over.
            if (currentScore >= 0)
            {
                textScore.text = "Keys found:" + currentScore;

            }
            else
            {
                playerDead = true;
                //textScore.text = "GAME OVER ! YOU LOSE!";
               GameOver();
                

            }

        }

    }


    void GameOver()
    {
        Debug.Log("PLAYER DEAD");

        Destroy(this);

        Application.LoadLevel(2);
        

    }
}
