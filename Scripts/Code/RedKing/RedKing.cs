using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class RedKing : MonoBehaviour
{
    private Animator redKingAnimator;
    public ParticleSystem damageParticle;
    private float scaleX;
    private float scaleY;
    public bool isAlive = true;
    public bool isReborned;
    private int animatorState = 0;
    public int shootedEnemy;
    private GameObject rebornPackage;
    public AudioSource audioSource;

    private void Awake()
    {
        Application.targetFrameRate = 120;
    }
    void Start()
    {
        rebornPackage = GameObject.Find("RebornPackage");
        //damageParticle = GetComponent<ParticleSystem>();
        redKingAnimator = GetComponent<Animator>();
        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;
        rebornPackage.SetActive(false);
        isReborned = false;
        shootedEnemy = 0;

        //PlayerPrefs.DeleteAll();
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //on trigger enter bulunduğu collider ( çarpışmayı algılayan bileşen) ile çarpışan objeleri belirler. çarpışan nesnelerin tagına göre olacakları kodladığımız yer.
        if (( collision.CompareTag("enemyBlackCircleTag") || collision.CompareTag("enemySpikeTag") || collision.CompareTag("enemyBlackSquareTag") ) && isAlive == true)
        {
            animatorState = 1;
            
            //Debug.Log(collision.tag);
            if (transform.localScale.x <= 0.30 && collision.CompareTag("enemyBlackCircleTag"))
            {
                scaleX += 0.03f;
                scaleY += 0.03f;
                collision.gameObject.SetActive(false);
                damageParticle.Play();
                audioSource.Play();
            }
            else if(collision.CompareTag("enemyBlackCircleTag")) 
            {
                scaleX += 0.015f;
                scaleY += 0.015f;
                audioSource.Play();
            }

            if (transform.localScale.x <= 0.30 && collision.CompareTag("enemySpikeTag"))
            {
                scaleX += 0.04f;
                scaleY += 0.04f;
                collision.gameObject.SetActive(false);
                damageParticle.Play();
                audioSource.Play();
            }
            else if(collision.CompareTag("enemySpikeTag"))
            {
                scaleX += 0.02f;
                scaleY += 0.02f;
                audioSource.Play();
            }

            if (transform.localScale.x <= 0.30 && collision.CompareTag("enemyBlackSquareTag"))
            {
                scaleX += 0.03f;
                scaleY += 0.03f;
                collision.gameObject.SetActive(false);
                damageParticle.Play();
                audioSource.Play();
            }
            else if(collision.CompareTag("enemyBlackSquareTag"))
            {
                scaleX += 0.02f;
                scaleY += 0.02f;
                audioSource.Play();
            }

            StartCoroutine(ChangeAnimation(animatorState));
            collision.gameObject.SetActive(false);
            transform.localScale = new Vector3(scaleX, scaleY, transform.localScale.z);
            
        }

        if (collision.CompareTag("spitleTag") && isAlive)
        {
            animatorState = 1;
            scaleX += 0.01f;
            scaleY += 0.01f;
            Destroy(collision.gameObject);
            StartCoroutine(ChangeAnimation(animatorState));
            collision.gameObject.SetActive(false);
            transform.localScale = new Vector3(scaleX, scaleY, transform.localScale.z);
        }

        else if (collision.CompareTag("enemyWhiteSquareTag") || collision.CompareTag("rebornWhiteSquareTag") || collision.CompareTag("tutorialWhiteSquareTag"))
        {
            // farklı renkte particke eklenebilir. Gülme animasyonu yapılabilir iyileştiğinde
            if (transform.localScale.x > 0.15f)
            {
                animatorState = 3;
                if (transform.localScale.x <= 0.30)
                {
                    scaleX -= 0.055f;
                    scaleY -= 0.055f;
                    
                }
                else
                {
                    scaleX -= 0.03f;
                    scaleY -= 0.03f;
                }
            }

          
            transform.localScale = new Vector3(scaleX, scaleY,transform.localScale.z);
            collision.gameObject.SetActive(false);
            StartCoroutine(ChangeAnimation(animatorState));
        }

    }
    // IE Numeratorler araya bekleme süresi koymak için oldukça işlevli seçeneklerden biri. Animasyon 1 frame içerisinde 2 kez değişirse haliyle gözükemez. Bunun için hasar yedikten sonra bir süre bekleyip öyle değiştiriyoruz.
    IEnumerator ChangeAnimation(int state)
    {
        redKingAnimator.SetInteger("State", state);
        yield return new WaitForSeconds(0.1f);
        redKingAnimator.SetInteger("State", 0);
    }


    public void Die()
    {
        StartCoroutine(DieState());
        //degisti
    }

    IEnumerator DieState()
    {
        isAlive = false;
        redKingAnimator.SetInteger("State", 2);
        yield return new WaitForSeconds(2f);
    }

    public void Reborn()
    {
        rebornPackage.SetActive(true);
        if (transform.localScale.x < 0.4f)
        {
            redKingAnimator.SetInteger("State", 0);
        }
        isReborned = true;
        StartCoroutine(ResetPlayerScale());
        
    }

    IEnumerator ResetPlayerScale()
    {
        yield return new WaitForSeconds(3);
        isAlive = true;
        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;
    }
}
