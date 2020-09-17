using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class projectileMovement : MonoBehaviour
{
    Rigidbody2D rgbd;
    knocker knocker;

    public GameObject[] deadStain;
    public GameObject[] whiteDeadStain;
    public ParticleSystem shooting;
    public ParticleSystem shotWhite;
    public AudioSource popSound;
    Text textScore;


    RedKing kingScript;
    GameObject redKing;


    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();


        redKing = GameObject.FindGameObjectWithTag("Player");

        kingScript = redKing.GetComponent<RedKing>();
        textScore = GameObject.FindGameObjectWithTag("scoreTag").GetComponent<Text>();
    }

    void FixedUpdate()
    {
        move();
        destroyProjectile();
    }
    
    void destroyProjectile()
    {
        float distance;
        distance = Vector3.Distance(redKing.transform.position, transform.position);
        if(distance > 10)
        {
            Destroy(gameObject);
        }

    }

    void move()
    {
        transform.position = Vector2.MoveTowards(transform.position, transform.position.normalized*300, 17 * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "enemyBlackCircleTag" || col.gameObject.tag == "enemySpikeTag" || col.gameObject.tag == "enemyBlackSquareTag")
        {
            popSound.Play();
            Instantiate(shooting, col.gameObject.transform.position, Quaternion.identity);
            CreateDeadStain(col.transform.position);
            Destroy(col.gameObject);
            knocker.newEnemyCount++;
            kingScript.shootedEnemy++;
            textScore.text = knocker.newEnemyCount.ToString();
        }


        if (col.gameObject.tag == "enemyWhiteSquareTag" || col.gameObject.tag == "tutorialWhiteSquareTag")
        {
            popSound.Play();
            Instantiate(shotWhite, col.gameObject.transform.position, Quaternion.identity);
            CreateWhiteDeadStain(col.transform.position);
            Destroy(col.gameObject);
            knocker.newEnemyCount--;
            textScore.text = knocker.newEnemyCount.ToString();

        }
    }

    void CreateDeadStain(Vector3 vec)
    {

        int i = Random.Range(0, 6);
        Instantiate(deadStain[i], vec, Quaternion.identity);

    }

    void CreateWhiteDeadStain(Vector3 vec)
    {
        int i = Random.Range(0, 3);
        Instantiate(whiteDeadStain[i], vec, Quaternion.identity);
    }
}
