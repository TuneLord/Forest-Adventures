using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public int startingEnemyHealth = 100;           
    public int currentEnemyHealth;                  
    public float sinkSpeed = 2.5f;                                            

    Animator anim;                              
    AudioSource enemyAudio;                    
    ParticleSystem hitParticles;                
    CapsuleCollider capsuleCollider;
    private NavMeshAgent nav;
    bool isDead;                                
    bool isSinking;                            


    void Awake()
    {
        anim = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        currentEnemyHealth = startingEnemyHealth;
    }

    void Update()
    {

        if (isSinking)
        {

            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
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

       
        capsuleCollider.isTrigger = true;

        anim.SetTrigger("Dead");
        Destroy(gameObject);
    }


    public void StartSinking()
    {
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;

        isSinking = true;

        Destroy(gameObject, 2f);
    }
}