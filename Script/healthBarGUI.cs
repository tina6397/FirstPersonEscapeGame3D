using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class healthBarGUI : MonoBehaviour {


    public float currentHealth;
    public float maxHealth = 100;
    public Image Bar;

	// Use this for initialization
	void Start () {
        Bar = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        currentHealth = PlayerHealthManager.currentHealth;
        Bar.fillAmount = currentHealth / maxHealth;

        if(currentHealth<60)
        {
            Bar.color = Color.red;
        }
        else
        {
            Bar.color = Color.white;
        }
	}
}
