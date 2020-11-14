using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [Header("Player Data")]
    public GameManager playerData;
    private Rigidbody2D rig;
    public Sprite[] rockSprites;
    public int randomRotation;
    public bool rockl = true;
    public GameObject destroyAnim;

    public void DestroyAnimation()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        if (rockl)
        {
            randomRotation = Random.Range(-5, 5);
            GetComponent<SpriteRenderer>().sprite = rockSprites[Random.Range(0, rockSprites.Length)];
            rig = GetComponent<Rigidbody2D>();
        }

    }


    void FixedUpdate()
    {
        if (rockl)
        {
            rig.gravityScale = playerData.SpeedRock;

            transform.Rotate(new Vector3(0, 0, randomRotation));
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player" )
        {
            Instantiate(destroyAnim,transform.position,Quaternion.identity);
            playerData.HealthPlayer--;
            Destroy(gameObject);
        }


        if(collision.transform.tag == "Destroy")
        {
         
            Destroy(gameObject);
        }

        if (collision.transform.tag == "Point")
        {
            Instantiate(destroyAnim, transform.position, Quaternion.identity);
            playerData.Point++;
            Destroy(gameObject);
        }
    }

   

}
