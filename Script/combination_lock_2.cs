using UnityEngine;
using System.Collections;

public class combination_lock_2 : MonoBehaviour {


    public bool clicked;
    public int index;

    // Use this for initialization
    void Start()
    {
        clicked = false;
        index = 0;
    }

    public void OnMouseDown()
    {
        index++;
        if (index == 10)
        {
            index = 0;
        }
        combination_lock_manager.lock2 = index;
        //Debug.Log(combination_lock_manager.lock1);

    }

    // Update is called once per frame
    void Update()
    {
        Quaternion targetRotation = Quaternion.Euler(0, 270, 271 - 36 * index);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, 2f * Time.deltaTime);

    }
}
