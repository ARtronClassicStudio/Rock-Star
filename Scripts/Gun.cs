using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Player Data")]
    public GameManager playerData;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.tag == "Destroy")
        {
            Destroy(gameObject);
        }


        if (collision.transform.tag == "Rock")
        {
            Destroy(gameObject);
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<BoxCollider2D>().isTrigger = false;
        playerData.RunGun = true;
    }

   

}
