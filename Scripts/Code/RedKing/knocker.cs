using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class knocker : MonoBehaviour
{

    GameObject redKing;
    public GameObject[] deadStain;
    public GameObject[] deadStainWhite;

    public Text textScore;

    public static int newEnemyCount = 0;
    public ParticleSystem shooting;
    public ParticleSystem shotWhite;
    public AudioSource popSound;

    void Start()
    {
        redKing = GameObject.FindGameObjectWithTag("Player");
    }




    void OnTriggerEnter2D(Collider2D col)
    {
   
        if (col.gameObject.tag == "enemyBlackCircleTag" || col.gameObject.tag == "enemyBlackSquareTag" || col.gameObject.tag == "enemySpikeTag")
        {
            popSound.Play();
            // Düşman çarptığı zaman çarptığı yerde bir patlama efekti instantiate edilir(üretilir). Ardından çarpan obje yok edilerek skora dönüşür. Öldüğü yerde de iz oluşturmak için deatstain fonksiyonumuzu kullanıyoruz.
            Instantiate(shooting,col.gameObject.transform.position,Quaternion.identity);
            CreateDeadStain(col.transform.position);
            Destroy(col.gameObject);
            newEnemyCount++;
            textScore.text = newEnemyCount.ToString();
        }

        if (col.gameObject.tag == "enemyWhiteSquareTag" || col.gameObject.tag =="tutorialWhiteSquareTag")
        {
            popSound.Play();
            Instantiate(shotWhite, col.gameObject.transform.position, Quaternion.identity);
            CreateDeadStain_White(col.transform.position);
            Destroy(col.gameObject);
            newEnemyCount--;
            textScore.text = newEnemyCount.ToString();

        }
    }

    void CreateDeadStain(Vector3 vec)
    {

        int i = Random.Range(0,6);
        Instantiate(deadStain[i],vec,Quaternion.identity);

    }

    void CreateDeadStain_White(Vector3 vec)
    {

        int i = Random.Range(0, 3);
        Instantiate(deadStainWhite[i], vec, Quaternion.identity);

    }
}
