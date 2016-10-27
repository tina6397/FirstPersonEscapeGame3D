using UnityEngine;
using System.Collections;

public class combination_lock_manager2 : MonoBehaviour
{


    public static int lock1;
    public static int lock2;
    public static int lock3;
    private int lock1_ans;
    private int lock2_ans;
    private int lock3_ans;

    private int blue;
    private int green;
    private int red;
    private int white;
    private int black;
    private int yellow;
    private int magenta;
    private int cyan;

    // Use this for initialization
    void Start()
    {
        lock1 = 0;
        lock2 = 0;
        lock3 = 0;
       
        lock1_ans = 7;
        lock2_ans = 2;
        lock3_ans = 8;
    }

    // Update is called once per frame
    void Update()
    {

        if (lock1 == lock1_ans && lock2 == lock2_ans && lock3 == lock3_ans)
        {
            //unlock key chain
            Quaternion targetRotation = Quaternion.Euler(-130f, 0, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, 2f * Time.deltaTime);

        }
    }
}
