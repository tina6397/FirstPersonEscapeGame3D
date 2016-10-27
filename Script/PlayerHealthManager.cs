using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;



    public class PlayerHealthManager : MonoBehaviour
    {


        public static double currentHealth ;
        public static  bool attachReady;
        public Text textHealth;
         public static int minimumAttackHealth;
        public String attackText;
        //public Text attackReadyText;

        void Awake()
        {
        currentHealth = 100f;
        attackText = "";
            textHealth = GetComponent<Text>();
        //attackReadyText = GetComponent<Text>();
            attachReady = true;
        minimumAttackHealth = 70;


        //if (attachReady)
        //{
        //    attackReadyText.text = "YOU CAN ATTACK NOW";
        //}
        //else
        //{
        //    attackReadyText.text = "";

        //}
    }

    void Update()
    {
        if (attackReady())
        {
            attackText = "YOU CAN ATTACK NOW";
        }
        else
        {
            attackText = "NOT ENOUGH HEALTH TO ATTACK";
        }
        textHealth.text = "Your health:" + Math.Round(currentHealth) + "/100" + attackText;

    }


    public static void IncreaseHealth(double i)
        {
            if((currentHealth + i) > 100)
            {
            currentHealth = 100;
            }
            else
            {
            currentHealth = currentHealth + i;
            }
        }

        public static void DecreaseHealth(double i)
        {
            if ((currentHealth - i) < 0)
            {
                currentHealth = 0;
            }
            else
            {
                currentHealth = currentHealth - i;
            }
        }

    //check if player health is enough to attack
        public static bool attackReady()
        {
        return (Math.Round(currentHealth) >= minimumAttackHealth);
        }
 
    // Update is called once per frame

   
    }

