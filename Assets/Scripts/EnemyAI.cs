using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour {
    public GameObject Player1, Player2;
    private NavMeshAgent nav;
    PlayerController playerController1, playerController2;
    public Slider HealthSlider;  
    private bool isGameOver = false; 
    public float timeBetweenAttacks = 0.7f;
    public int attackDamage = 5;
    public int attackPlayerDamage = 50;
    bool playerInRange;
    float timer;
    float dystans;
    public int startingEnemyHealth = 100;
    public int currentEnemyHealth;
    public float sinkSpeed = 2.5f;
    bool isDead;
    private Animator anim;

    void Awake()
    {
        Player1 = GameObject.Find("Player1");
        Player2 = GameObject.Find("Player2");
        if (Player1.activeInHierarchy)
            playerController1 = Player1.GetComponent<PlayerController>();
            currentEnemyHealth = startingEnemyHealth;

        if (Player2.activeInHierarchy)
            playerController2 = Player2.GetComponent<PlayerController>();
            currentEnemyHealth = startingEnemyHealth;
    }
    public void TakeEnemyDamage(int amount)
    {

        if (isDead)

            return;

        currentEnemyHealth -= amount;

        if (currentEnemyHealth <= 0)
        {
            Death();
        }
    }
    void Death()
    {

        isDead = true;
        Destroy(gameObject);
    }

    // Use this for initialization
    void Start ()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Player1.activeInHierarchy)
        {
            dystans = Vector3.Distance(transform.position, Player1.transform.position); 
        }
        else
            dystans = Vector3.Distance(transform.position, Player2.transform.position);

        timer += Time.deltaTime;

        if (Player1.activeInHierarchy)
            nav.SetDestination(Player1.transform.position); 
        else
            nav.SetDestination(Player2.transform.position);
        if (timer >= timeBetweenAttacks && playerInRange && currentEnemyHealth > 0)
        {
            Attack();
        }

        if (playerController1.currentHealth <= 0 || playerController2.currentHealth <= 0)
        {
            
        }

        if (currentEnemyHealth <= 0)
        {
            Destroy(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.K) && dystans <= 2 )
        {
            currentEnemyHealth -= attackPlayerDamage;
            anim.Play("Melee_Stab");
        }
    }

   
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player1)
        {
            playerInRange = true;
        }
        if (other.gameObject == Player2)
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player1)
        {
            playerInRange = false;
        }
        if (other.gameObject == Player2)
        {
            playerInRange = false;
        }
    }
    void Attack()
    {
        timer = 0f;

        if (playerController1.currentHealth > 0)
        {
            playerController1.TakeDamage(attackDamage);
        }
        if (playerController2.currentHealth > 0)
        {
            playerController2.TakeDamage(attackDamage);
        }

    }
}