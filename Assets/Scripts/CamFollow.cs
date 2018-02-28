using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{

    public GameObject Player1, Player2;
    private Vector3 offset;
  

    void Start()
    {
        if (Player1.activeInHierarchy)
        offset = transform.position - Player1.transform.position;
        else
        offset = transform.position - Player2.transform.position;


    }

    void Update()
    {
        if (Player1.activeInHierarchy)
            transform.position = Player1.transform.position + offset;
          else
            transform.position = Player2.transform.position + offset;
    }   
    /* void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(new Vector3(30, 45, 0));
    } */
}
