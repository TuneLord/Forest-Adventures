using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour {
    private GameObject Player1, Player2;
    PlayerController playerController1, playerController2;
    bool playerInRange;


    void Awake()
    {
        Player1 = GameObject.Find("Player1");
        Player2 = GameObject.Find("Player2");
        if (Player1.activeInHierarchy)
            playerController1 = Player1.GetComponent<PlayerController>();

        if (Player2.activeInHierarchy)
            playerController2 = Player2.GetComponent<PlayerController>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player1)
        {
            playerInRange = true;
            PlayerPrefs.GetInt("count");
            PlayerPrefs.Save();
            SceneManager.LoadScene("Level1");

        }
        if (other.gameObject == Player2)
        {
            playerInRange = true;
            playerInRange = true;
            PlayerPrefs.GetInt("count");
            PlayerPrefs.Save();
            SceneManager.LoadScene("Level1");
        }
    }
}
