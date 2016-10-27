using UnityEngine;
using System.Collections;

public class combination_lock_manager : MonoBehaviour {


    public static int lock1;
    public static int lock2;
    public static int lock3;
    private int lock1_ans;
    private int lock2_ans;
    private int lock3_ans;

    private int blue ;
    private int green ;
    private int red ;
    private int white;
    private int black;
    private int yellow;
    private int magenta;
    private int cyan;

	// Use this for initialization
	void Start () {
        lock1 = 0;
        lock2 = 0;
        lock3 = 0;
        blue = 3;
        green = 2;
        red = 1;

        white = red+green+blue;
        black = 0;

        yellow = red + green;
        magenta = red + blue;
        cyan = green + blue;

        lock1_ans = blue;
        lock2_ans = white;
        lock3_ans = cyan;
    }
	
	// Update is called once per frame
	void Update () {

        if (lock1==lock1_ans&&lock2==lock2_ans&&lock3==lock3_ans)
        {
            //unlock key chain
            Debug.Log("UN LOCK CHAIN");
            Quaternion targetRotation = Quaternion.Euler(-130f, 0, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, 2f * Time.deltaTime);

        }
    }
}
