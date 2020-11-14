using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [Header("Player Data")]
    public GameManager playerData;
    public GameObject XP;
    public GameObject rock;
    [Header("Speed Spawn Rock")]
    public float speedSpawn = 1;
    [Header("Min Max X Pose")]
    public float minpos = -1,maxpos = 1;
    public float nextLevel = 10;




    private void Start()
    {
      
        StartCoroutine(RockSpawnPrefab());
        StartCoroutine(XPSpawnPrefab());
    }

    private void Update()
    {
        if (playerData.Point > nextLevel)
        {
          
            
                nextLevel += 10;
                speedSpawn -= 0.01f;

        }

 
    }

    IEnumerator XPSpawnPrefab()
    {
        yield return new WaitForSeconds(20);

        var xpSpawn = Instantiate(XP);
        xpSpawn.transform.position = new Vector3(Random.Range(minpos, maxpos), transform.position.y, 0);
        StartCoroutine(XPSpawnPrefab());
    }


    IEnumerator RockSpawnPrefab()
    {
        yield return new WaitForSeconds(speedSpawn);
        
        var rockSpawn =  Instantiate(rock);
            rockSpawn.transform.position = new Vector3(Random.Range(minpos, maxpos), transform.position.y, 0);
        StartCoroutine(RockSpawnPrefab());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(new Vector3(minpos,transform.position.y),0.5f);
        Gizmos.DrawSphere(new Vector3(maxpos,transform.position.y),0.5f);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(minpos, transform.position.y), new Vector3(maxpos, transform.position.y));

        
    }

}
