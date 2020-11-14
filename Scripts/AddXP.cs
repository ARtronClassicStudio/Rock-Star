using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddXP : MonoBehaviour
{
    [Header("Player Data")]
    public GameManager playerData;
    private Rigidbody2D rig;


    private void Start()
    {
       

      rig = GetComponent<Rigidbody2D>();
       

    }

    void FixedUpdate()
    {
    
            rig.gravityScale = playerData.SpeedRock;


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.tag == "Destroy")
        {

            Destroy(gameObject);
        }


        if (collision.transform.tag == "Player")
        {

            playerData.HealthPlayer++;
            Destroy(gameObject);
        }
    }

   
   
}