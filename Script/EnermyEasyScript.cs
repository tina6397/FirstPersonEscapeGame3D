using UnityEngine;
using System.Collections;

public class EnermyEasyScript : MonoBehaviour {

    Transform player;
    ScoreManager playerScore;
    PlayerHealthManager playerHealth;
    NavMeshAgent nav;
    float sightDistance;
    float attackDistance;
    float attackByPlayerDIstance;
    bool attacked;
    bool attackedPlayer;
    int keys;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerScore = GetComponent<ScoreManager>();
        playerHealth = GetComponent<PlayerHealthManager>();
        nav = GetComponent<NavMeshAgent>();
        sightDistance = 70;
        attackDistance = 15;
        attackByPlayerDIstance = 25;
        attacked = false;
        attackedPlayer = false;
        keys = 1;

    }


    public void OnMouseDown()
    {
        
        //check if player is able to attack -- 1. health is enought 2.player is near enough to enemy
        if((PlayerHealthManager.attackReady())&&(playerDistance() < attackByPlayerDIstance))
        {
            attacked = !attacked;

        }
    }

    void FixedUpdate()
    {
    }

    //return the distance between player and enemy
    public float playerDistance()
    {
        return Vector3.Distance(this.transform.position, player.position);
    }

    // Update is called once per frame
    void Update()
    {
       //CHASE PLAYER -- if see player within eyesight, chase him, if not, patrol randomly
        if (playerDistance() < sightDistance)
        {
            
            if (true)
            {
                Chase();

            }
        }
        else
        {
            Patrolling();
        }

        //ATTACKED BY PLAYER -- reduce enemy keys when attacked + increase player key
        if (attacked)
        {
            keys--;
            ScoreManager.currentScore += 1;
            gameObject.active = false;

            attacked = !attacked;

        }

        //ATTACK PLAYER -- when distance is close enought to attack player. steal keys!
        if ((playerDistance() < attackDistance)&&(!attackedPlayer))
        {

            keys++;
            ScoreManager.currentScore -= 1;
            attackedPlayer = true;
        }
    }

    void Patrolling()
    {

    }

    void Chase()
    {
        nav.SetDestination(player.position);
        

    }
}
