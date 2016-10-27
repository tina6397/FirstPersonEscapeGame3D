using UnityEngine;
using System.Collections;

public class EnemyHardRabbit : MonoBehaviour {

    Animator anim;
    Transform player;
    CharacterController playerControl;


    ScoreManager playerScore;
    PlayerHealthManager playerHealth;
    NavMeshAgent nav;
    float sightDistance;
    float attackDistance;
    float attackByPlayerDIstance;
    bool attacked;
    string animationStatus;
    bool attackedPlayer;
    int keys;

    //BoxCollider col;
    SphereCollider col;

    float fieldOfViewAngle = 150f;

    bool foundPlayer;


    // Use this for initialization
    void Start()
    {


        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerScore = GetComponent<ScoreManager>();
        playerHealth = GetComponent<PlayerHealthManager>();
        nav = GetComponent<NavMeshAgent>();
        col = GetComponent<SphereCollider>();
        sightDistance = 100;
        attackDistance = 20;
        attackByPlayerDIstance = 25;
        attacked = false;
        attackedPlayer = false;
        keys = 1;

        anim = GetComponent<Animator>();
        playerControl = GetComponent<CharacterController>();

        foundPlayer = false;

    }


    public void OnMouseDown()
    {
        Debug.Log("CLICKCCCCCCCCCCCCCCCCCC");
        //check if player is able to attack -- 1. health is enought 2.player is near enough
        if ((PlayerHealthManager.attackReady()) && (playerDistance() < attackByPlayerDIstance))
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

        // Create a vector from the enemy to the player and store the angle between it and forward.
        Vector3 playerDirection = player.transform.position - transform.position;
        float playerAngle = Vector3.Angle(playerDirection, transform.forward);



        if (attacked)
        {
            AttackedByPLayer();
        }
        else
        {
            //ATTACK PLAYER -- when distance is close enought to attack player. steal keys!

            if ((playerDistance() < attackDistance) && (!attackedPlayer) )
            {

                Attack();
            }
            else
            {


                if ((playerDistance() < sightDistance) && (playerAngle < fieldOfViewAngle * 0.5f))
                {
                    Chase();

                    RaycastHit hit;
                    if (Physics.Raycast(transform.position , playerDirection.normalized, out hit, col.radius))
                    {
                        if (hit.collider.gameObject == player)
                        {
                            //chase him
                            foundPlayer = true;
                            Chase();
                            Debug.Log("RAYCASTING");

                        }

                        if (isHearing())
                        {
                            Chase();
                        }



                    }

                }
                else
                {
                    Patrolling();
                    foundPlayer = false;

                }
            }



            if (isHearing())
            {
                Chase();
            }


        }












        //DIE -- when keys less than 0
        //if (keys < 0)
        //{
        //    anim.SetTrigger("Dead");
        //    anim.Stop();
        //    nav.Stop();

        //}

        //if (ScoreManager.currentScore < 0)
        //{
        //   player.gameObject.SetActive(false);
        //    Application.LoadLevel(2);
        //}

    }


    //ATTACKED BY PLAYER -- reduce enemy keys when attacked + increase player key
    void AttackedByPLayer()
    {
        keys--;
        ScoreManager.currentScore += 1;
        anim.SetTrigger("Dead");

        //trigger enemy to play dead animation
        //anim.SetTrigger("Attacked");

        //Decrease player health 
        PlayerHealthManager.DecreaseHealth(20);


        nav.Stop();
        attacked = !attacked;
        //gameObject.active = false;

        //gameObject.SetActive(false);



    }



    void Patrolling()
    {


    }

    // A method for attacking the player
    void Attack()
    {

        nav.Stop();
        anim.SetTrigger("AttackPlayer");

        keys++;
        attackedPlayer = true;
        ScoreManager.currentScore -= 1;
        

        //anim.Play("Walk");

    }

    bool isHearing()
    {
        bool hearing = false;

        //go through every audio source in the game and..
        foreach (AudioSource aud in GameObject.FindObjectsOfType(typeof(AudioSource)))
        {
            float distance = Vector3.Distance(transform.position, aud.transform.position);

            //if that audio source is playing AND if audio is close enough
            if ((aud.isPlaying) && (distance < 50))
            {
                hearing = true;
                return true;
            }
        }

        return hearing;
    }

    void Chase()
    {
        nav.SetDestination(player.position);

        //if ((anim.GetCurrentAnimatorStateInfo(0).IsName("Walk")))
        //{
        //    anim.Play("Walk");
        //}

    }

    void onTriggerEnter(Collider other)
    {
        Debug.Log("Collided with " + other.gameObject.name);

        if (other.gameObject.tag == "Player") { Chase(); }
        Debug.Log("Collided with " + other.gameObject.name);


    }

    void onTriggerStay(Collider other)
    {
        Debug.Log("Collided with " + other.gameObject.name);

        if (other.gameObject.tag == "Player") { Chase(); }

    }
}
