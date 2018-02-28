using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using System;

public class PlayerController : MonoBehaviour {
 
    public int startingHealth = 100;
    public int currentHealth;
    public Image DamageImage;
    private int count;
    public Text countText;
    public Slider HealthSlider;  //reference for slider
    private bool isGameOver = false; //flag to see if game is over
    bool isDead;
    bool damaged;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public float sinkSpeed = 2.5f;
    private Animator anim;
    public GameObject Player1,Player2;
    PlayerController playerController;
    public float timeBetweenAttacks = 0.7f;
    private float OldPositionX;
    private float OldPositionZ;
    bool isMove = false;


    [SerializeField]
    float moveSpeed = 4f;

    Vector3 forward, right;
    bool jump = false;
    float jumpHeight = 3f, jumpSpeed = 10f;
    Rigidbody rb;
    

    void Awake()
    { 
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        
    }

    // Use this for initialization
    void Start ()
    {
        count = 0;
        SetCountText();
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        rb = GetComponent<Rigidbody>();

    }


    // Update is called once per frame
    void Update()
    {
        Idle();
        if (Input.GetButtonDown("HorizontalKey1"))
        {
            Move();
            anim.Play("Run_Static");
            isMove = true;
        }
        if (Input.GetButtonDown("VerticalKey1"))
        {
            Move();
            anim.Play("Run_Static");
            isMove = true;
        }
        if (transform.position.y < -2)
        {
            anim.Play("Falling");
        }
        if (Input.GetKeyDown("escape"))
        {
            if (Time.timeScale == 1.0f)
                Time.timeScale = 0.0f;
            else
                Time.timeScale = 1.0f;
        }
        if (damaged)
        {
            DamageImage.color = flashColour;
        }
        else
        {
            DamageImage.color = Color.Lerp(DamageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;

        if (Input.GetButtonDown("Jump") && !jump && (isMove = true))
        {
            StartCoroutine(Jump());
            anim.Play("Running_Jump");
        }
        else if (Input.GetButtonDown("Jump") && !jump && (isMove = false))
        {
            StartCoroutine(Jump());
            anim.Play("Standing_Jump");

        }
        else
            Move();
    }
    void Move()
    {
        isMove = true;
        float hori = Input.GetAxis("HorizontalKey1");
        float vert = Input.GetAxis("VerticalKey1");

        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey1");

        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey1");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
      
        if (hori != 0 || vert !=0)
        {
            transform.forward = heading;
        }
     
        transform.position += rightMovement;
        transform.position += upMovement;
    }
    IEnumerator Jump()
    {
        float originalHeight = transform.position.y;
        float maxHeight = originalHeight + jumpHeight;
        rb.useGravity = false;


        jump = true;
        yield return null;

        while (transform.position.y < maxHeight)
        {
            transform.position += transform.up * Time.deltaTime * jumpSpeed;
            yield return null;
        }
        //rb.useGravity = true;

        //rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        while (transform.position.y > originalHeight)
        {
            transform.position -= transform.up * Time.deltaTime * jumpSpeed;
            yield return null;
        }

        rb.useGravity = true;
        jump = false;

        yield return null;

    }
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("StandardMushroom"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        if (other.gameObject.CompareTag("EpicMushroom"))
        {
            other.gameObject.SetActive(false);
            count = count + 10;
        }
        PlayerPrefs.GetInt("count");
        PlayerPrefs.Save();
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        if (Time.timeScale == 1.0f)
            Time.timeScale = 0.0f;
        else
            Time.timeScale = 1.0f;
    }

    void SetCountText()
    {
        countText.text = "Mushroom: " + count.ToString();
    }
   
    public void TakeDamage(int amount)
    {
        damaged = true;
        currentHealth -= amount;
        HealthSlider.value = currentHealth;

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }
    public void HealHero(int amount)
    {
        damaged = true;
        currentHealth += amount;
        HealthSlider.value = currentHealth;

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }
    public void Death()
    {
        int number;
        number = UnityEngine.Random.Range(1, 10);
        isDead = true;

        if (number >= 5)
        {
            anim.Play("Death_01");
        }
        else
        {
            anim.Play("Death_02");
        }

        StartCoroutine(Wait());
        
    }
    void Idle()
    {
        int numbers;
        numbers = UnityEngine.Random.Range(1, 70);

        if (numbers <= 10)
        {
            anim.Play("Idle_WipeMouth");
        }
        if (numbers <= 20 && numbers > 10)
        {
            anim.Play("Idle_Smoking");
        }
        if (numbers <= 30 && numbers > 20)
        {
            anim.Play("Idle_SexyDance");
        }
        if (numbers <= 40 && numbers > 30)
        {
            anim.Play("Idle_HandOnHips");
        }
        if (numbers <= 50 && numbers > 40)
        {
            anim.Play("Idle_CrossedArms");
        }
        if (numbers <= 60 && numbers > 50)
        {
            anim.Play("Idle_CheckWatch");
        }
        if (numbers <= 70 && numbers > 60)
        {
            anim.Play("Idle");
        }
    }

    }
