using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    [Header("Player Data")]
    public GameManager playerData;
    [Header("GameObject")]
    public GameObject Gun;
    public GameObject game;
    public GameObject gameover;
    public GameObject destroyAnim;
    [Header("int & float")]
    public int health;
    public float speedRock;
    public float speedPlayer = 1;
    [Header("UI Text")]
    public Text textXP;
    public Text textPoints;
    public Text textPointsGameOver;
    [Header("Order")]
    public Vector2 position;
    private Animation anim;
    public AudioClip clip;
    private AudioSource audios;

    public SpriteRenderer sprite1, sprite2;
    void Start()
    {
        audios = GetComponent<AudioSource>();
        anim = GetComponent<Animation>();
        playerData.HealthPlayer = health;
        playerData.SpeedRock = speedRock;
        sprite1.enabled = true;
        sprite2.enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
    }

  
    public void Restart()
    {
        SceneManager.LoadScene(0);

    }

    void Update()
    {


        if (playerData.HealthPlayer <= 0)
        {
            textPointsGameOver.text = "Points:" + playerData.Point.ToString();
            game.SetActive(false);
            gameover.SetActive(true);
            sprite1.enabled = false;
            sprite2.enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }

        textXP.text ="x" +playerData.HealthPlayer.ToString();
        textPoints.text = "Points:" + playerData.Point.ToString();
        transform.position = new Vector2(position.x,transform.position.y);

        if (Input.GetKeyDown(KeyCode.Space) && playerData.RunGun)
        {
        
       
                audios.clip = clip;
                audios.Play();
         

            playerData.RunGun = false;
            Instantiate(Gun,new Vector3(transform.position.x,transform.position.y,1),Quaternion.Euler(Vector3.zero)); 
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            anim.CrossFade("RightPlayer");
            position.x += Time.deltaTime * speedPlayer;
            position.x = Mathf.Clamp
                (
                position.x, -Camera.main.orthographicSize * Screen.width / Screen.height,
                Camera.main.orthographicSize * Screen.width / Screen.height
                );
        }
        else
        {
            anim.CrossFade("Idle");
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            anim.CrossFade("LeftPlayer");
            position.x -= Time.deltaTime * speedPlayer;
            position.x = Mathf.Clamp
                (
                position.x,-Camera.main.orthographicSize * Screen.width / Screen.height,
                Camera.main.orthographicSize * Screen.width / Screen.height
                );
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.transform.tag == "Rock")
        {
            Instantiate(destroyAnim, transform.position, Quaternion.identity);
            sprite1.enabled = false;
            sprite2.enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(GodMode());
        }
        
    }

    IEnumerator GodMode()
    {
        yield return new WaitForSeconds(0.5f);
        sprite1.enabled = false;
        sprite2.enabled = false;
        yield return new WaitForSeconds(0.5f);
        sprite1.enabled = true;
        sprite2.enabled = true;
        yield return new WaitForSeconds(0.5f);
        sprite1.enabled = false;
        sprite2.enabled = false;
        yield return new WaitForSeconds(0.5f);
        sprite1.enabled = true;
        sprite2.enabled = true;
        yield return new WaitForSeconds(0.5f);
        sprite1.enabled = false;
        sprite2.enabled = false;
        yield return new WaitForSeconds(0.5f);
        sprite1.enabled = true;
        sprite2.enabled = true;
        yield return new WaitForSeconds(0.5f);
        sprite1.enabled = false;
        sprite2.enabled = false;
        yield return new WaitForSeconds(0.5f);
        sprite1.enabled = true;
        sprite2.enabled = true;
        yield return new WaitForSeconds(0.5f);

        GetComponent<BoxCollider2D>().enabled = true;
    }


    private void OnDrawGizmos()
    {
        
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(new Vector3(Camera.main.orthographicSize  * Screen.width / Screen.height, transform.position.y), 0.5f);
        Gizmos.DrawSphere(new Vector3(-Camera.main.orthographicSize  * Screen.width / Screen.height, transform.position.y), 0.5f);
    }

}
