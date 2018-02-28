
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyStaticAI : MonoBehaviour
{
    public GameObject Player1, Player2;
    PlayerController playerController1, playerController2;
    private NavMeshAgent nav;
    EnemyHealth enemyHealth;
    float dystans;
    public Slider HealthSlider;  //reference for slider
    private bool isGameOver = false; //flag to see if game is over
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
    bool playerInRange;
    float timer;


    void Awake()
    {
        Player1 = GameObject.Find("Player1");
        Player2 = GameObject.Find("Player2");
        if (Player1.activeInHierarchy)
            playerController1 = Player1.GetComponent<PlayerController>();
            enemyHealth = GetComponent<EnemyHealth>();

        if (Player2.activeInHierarchy)
            playerController2 = Player2.GetComponent<PlayerController>();
            enemyHealth = GetComponent<EnemyHealth>();

    }

    // Use this for initialization
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        // nav.SetDestination(Player1.transform.position);
        if (Player1.activeInHierarchy)
        {
            dystans = Vector3.Distance(transform.position, Player1.transform.position);
        }
        else
            dystans = Vector3.Distance(transform.position, Player2.transform.position);

        if (dystans <= 10)
        {
            if (Player1.activeInHierarchy)
                nav.SetDestination(Player1.transform.position);
            else
                nav.SetDestination(Player2.transform.position);

            if (timer >= timeBetweenAttacks && playerInRange /*&& enemyHealth.currentEnemyHealth > 0*/)
            {
                Attack();
            }

            if (playerController1.currentHealth <= 0 || playerController2.currentHealth <= 0)
            {
                
            }

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

}