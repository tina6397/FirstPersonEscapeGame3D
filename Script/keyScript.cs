using UnityEngine;
using System.Collections;

public class keyScript : MonoBehaviour {


    public Vector3[] positions;

    // Use this for initialization
    void Start () {

        int randomeNumber = Random.Range(0, positions.Length);
        transform.position = positions[randomeNumber];
    }


    public void OnMouseDown()
    {
        //make key dissapear
        gameObject.active = false;

        //increase key count
        ScoreManager.currentScore += 1;
       

    }

    // Update is called once per frame
    void Update () {

    }
}
