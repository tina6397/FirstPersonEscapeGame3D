using UnityEngine;
using System.Collections;

public class EnemyHardRabbit2 : MonoBehaviour {

    Animator anim;
    GameObject player;
    CharacterController playerControl;

    float timer = 100f;
    Vector3 playerDirection;
    float playerAngle;

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

    BoxCollider col;

    float fieldOfViewAngle = 150f;

    public Vector3[] patrollPositions = new Vector3[2];


    bool foundPlayer;
    bool playerInSight;

    // Use this for initialization
    void Awake()
    {


        player = GameObject.FindGameObjectWithTag("Player");
        playerScore = GetComponent<ScoreManager>();
        playerHealth = GetComponent<PlayerHealthManager>();
        nav = GetComponent<NavMeshAgent>();
        col = GetComponent<BoxCollider>();
        sightDistance = 100;
        attackDistance = 20;
        attackByPlayerDIstance = 25;
        attacked = false;
        attackedPlayer = false;
        keys = 0;

        anim = GetComponent<Animator>();
        playerControl = GetComponent<CharacterController>();

        foundPlayer = false;
        playerInSight = false;


        //patrollPositions[0] = new Vector3(170, -12, -70);
        //patrollPositions[1] = new Vector3(155, -12, -220);


        //let the enemy patroll at the start of the scene.
        Patrolling();
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
        return Vector3.Distance(this.transform.position, player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {

        // Create a vector from the enemy to the player and store the angle between it and forward.
        //Vector3 playerDirection = player.transform.position - transform.position;
        //float playerAngle = Vector3.Angle(playerDirection, transform.forward);

        //CHeck if enemy is dead
        //if (keys == 0)
        //    {
        //        Dead();
        //    }
        //    else
        //    {

        //check if enemy is attacked by player
        if (attacked)
        {
            AttackedByPLayer();
        }
        else
        {
            //ATTACK PLAYER -- check when distance is close enought to attack player. steal keys!

            if ((playerDistance() < attackDistance) && (!attackedPlayer) && (playerInSight))
            {

                Attack();


            }
            else
            {

                //check if player is in sight, chase

                //if ((playerDistance() < sightDistance) && (playerAngle < fieldOfViewAngle * 0.5f))
                if (playerInSight)
                {



                    //foundPlayer = true;
                    Chase();
                    // Debug.Log("CHASEEEEEEEEEEEEEEE");

                }
                else
                {

                    if (isHearing())
                    {
                        Chase();
                    }
                    else
                    {
                        Patrolling();
                    }
                    // when player gets out of sight, stop chasing and patrol
                    //foundPlayer = false;

                }



            }
        }


        //NavMeshHit hit;
        //if (NavMesh.Raycast(transform.position, player.transform.position + transform.up, out hit, NavMesh.AllAreas))

        //{

        //    Debug.Log("RAYCAST HIT " + hit.ToString());
        //}
        //else
        //{
        //}

        //RaycastHit hit;
        //if (Physics.Raycast(transform.position + transform.up, playerDirection.normalized, out hit, 200f))
        //{
        //    Debug.Log("RAYYYYYyyyCASRRRST HIT" + hit.collider.gameObject);
        //}









        //DIE -- when keys less than 0
        //if (keys < 0)
        //{
        //    anim.SetTrigger("Dead");
        //    anim.Stop();
        //    nav.Stop();

        //}

        //if (ScoreManager.currentScore < 0)
        //{
        //    player.gameObject.SetActive(false);
        //}

    }


    //ATTACKED BY PLAYER -- reduce enemy keys when attacked + increase player key
    void AttackedByPLayer()
    {
        keys--;
        ScoreManager.IncreaseScore();
        anim.SetTrigger("Dead");
        nav.Stop();


        //trigger enemy to play dead animation
        //anim.SetTrigger("Attacked");

        //Decrease player health 
        PlayerHealthManager.DecreaseHealth(20);

        //delay the method for 2s before game over
        System.Threading.Timer timer = null;
        timer = new System.Threading.Timer((obj) =>
        {

            timer.Dispose();
            //gameObject.active = false;

        },
                    null, 2000, System.Threading.Timeout.Infinite);

        attacked = !attacked;

        if (keys < 0)
        {
            gameObject.SetActive(false);

        }



    }



    void Patrolling()
    {
        //LET THE ENEMY PATROL TO RANDOM LOCATIONS 
        //nav.Stop();
        int randomeNumber = Random.Range(0, patrollPositions.Length);
        nav.SetDestination(patrollPositions[randomeNumber]);
        nav.speed = 5;
    }

    // A method for attacking the player
    void Attack()
    {

        nav.Stop();
        anim.SetTrigger("AttackPlayer");
        keys++;
        attackedPlayer = true;
        ScoreManager.DecreaseScore();
        //player.SetActive(false);




        //while (timer > 0)
        //{
        //    timer -= Time.deltaTime;
        //    //Debug.Log("countdown: " + timer);
        //}

        //** THIS   METHOD IS MOVED TO THE SCOREMANAGER SCRIPT
        //delay the method for 2s before game over
        //System.Threading.Timer timer = null;
        //timer = new System.Threading.Timer((obj) =>
        //{

        //    timer.Dispose();
        //    //ScoreManager.currentScore -= 1;
        //    ScoreManager.DecreaseScore();

        //},
        //            null, 2000, System.Threading.Timeout.Infinite);




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
        nav.speed = 15;
        nav.SetDestination(player.transform.position);


    }

    //void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("Collided with " + other.gameObject.name);

    //   // if (other.gameObject.tag == "Player") { Chase(); }
    //   // Debug.Log("Collided with " + other.gameObject.name);


    //}

    void OnTriggerStay(Collider other)
    {



        if (other.gameObject.tag == "Player")
        {


            // Create a vector from the enemy to the player and store the angle between it and forward.
            playerDirection = player.transform.position - transform.position;
            playerAngle = Vector3.Angle(playerDirection, transform.forward);

            if (playerAngle < fieldOfViewAngle * 0.5f)
            {
                //RaycastHit hit;
                NavMeshHit hit;

                //Check if raycast hit any objects
                //  if (!Physics.Raycast(transform.position + transform.up, playerDirection.normalized, out hit, 200f))
                if (!NavMesh.Raycast(transform.position, player.transform.position + transform.up, out hit, NavMesh.AllAreas))
                {
                    //Debug.Log("RAYYCASRRRST HIT" + hit.collider.gameObject);
                    //check if the hit object is the player

                    // if (hit.collider.gameObject == player)

                    //  {
                    playerInSight = true;

                    Debug.Log("Player IN Sight ");

                    //  }
                }
                else
                {
                    playerInSight = false;
                    //  Debug.Log("Player OUT OF SIGHT!");
                    //Patrolling();
                }





            }


            //Chase(); 

        }

    }

    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("TRIGGER EXIT");
            playerInSight = false;
            Patrolling();

            //Chase(); 
        }

    }


    void Dead()
    {


        anim.SetTrigger("Dead");
        nav.Stop();
        Destroy(this);


        //AttackedByPLayer();
        //delay the method for 2s before game over
        System.Threading.Timer timer = null;
        timer = new System.Threading.Timer((obj) =>
        {

            timer.Dispose();
            gameObject.SetActive(false);



        },
                    null, 2000, System.Threading.Timeout.Infinite);


    }
}
