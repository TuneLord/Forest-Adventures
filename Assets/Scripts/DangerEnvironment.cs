using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DangerEnvironment : MonoBehaviour {
    private GameObject Player1, Player2;
    PlayerController playerController1, playerController2;
    public Image DamageImage;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public float flashSpeed = 5f;
    public Slider HealthSlider;
    private bool isGameOver = false;
    public float timeBetweenAttacksFire = 0.2f;
    public int attackDamageFire = 5;
    bool playerInRange;
    public int currentHealth;
    float timer;
   

    void Awake()
    {
        Player1 = GameObject.Find("Player1");
        Player2 = GameObject.Find("Player2");
        if (Player1.activeInHierarchy)
        playerController1 = Player1.GetComponent<PlayerController>();

        if (Player2.activeInHierarchy)
        playerController2 = Player2.GetComponent<PlayerController>();
    }
        //enemyHealth = GetComponent<EnemyHealth>();


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= timeBetweenAttacksFire && playerInRange/* && enemyHealth.currentHealth > 0*/)
        {
            Attack();
        }

        if (playerController1.currentHealth <= 0 || playerController2.currentHealth <= 0)
        {

        }
    }
    void Attack()
    {
        timer = 0.5f;

        if (playerController1.currentHealth > 0)
        {
            playerController1.TakeDamage(attackDamageFire);
            
        }
        if (playerController2.currentHealth > 0)
        {
            playerController2.TakeDamage(attackDamageFire);

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
