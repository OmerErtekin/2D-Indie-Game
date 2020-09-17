using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tukurenEnemyControl : MonoBehaviour
{
    SpriteRenderer sprite;
    GameObject redKing;

    public Sprite[] moveAnim;
    public Sprite[] tukurAnim;

    public float dist;

    float time_1 = 0;
    float time_2 = 0;
    float velocity;

    int move = 0;
    int tukur = 0;

    bool moveAnimCntrl = true;
    bool tukurAnimCntrl = false;
    private bool isFacingRight = false;

    public GameObject spitle;
    public GameObject spitlePoint;
    public RedKing kingScript;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        redKing = GameObject.FindGameObjectWithTag("Player");
        kingScript = redKing.GetComponent<RedKing>();
    }
    private void Update()
    {
        if(isFacingRight == false && transform.position.x - redKing.transform.position.x > 0)
        {
            Vector3 theScale = transform.localScale;
            isFacingRight = true;
            theScale.x = transform.localScale.x * -1;
            transform.localScale = theScale;
            
        }
        if(kingScript.isAlive == false)
        {
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        moveControl();
        if (moveAnimCntrl)
        {
            moveAnimation();

        }
        if (tukurAnimCntrl)
        {
            tukurAnimation();
        }
    }

    void moveAnimation()
    {
        time_1 += Time.deltaTime;
        if (time_1 > 0.15f)
        {
            sprite.sprite = moveAnim[move];
            move++;
            if (move == moveAnim.Length) 
            {
                move = 0;
            }
            time_1 = 0;
        }
    }

    void tukurAnimation()
    {
        time_2 += Time.deltaTime;
        if(time_2 > 0.9f)
        {
            if (tukur == 0)
            {
                Instantiate(spitle, spitlePoint.transform.position, Quaternion.identity);
            }
            sprite.sprite = tukurAnim[tukur];
            tukur++;
            if(tukur == tukurAnim.Length)
            {
                tukur = 0;
            }
            time_2 = 0;
        }
    }

    void moveControl()
    {
        Vector3 direction;
        direction = (redKing.transform.position - transform.position).normalized;

        float distance;
        distance = Vector3.Distance(redKing.transform.position, transform.position);

        if(distance>dist)
        {
            velocity = 0.03f;
            moveAnimCntrl = true;
            tukurAnimCntrl = false;
        }
        else
        {
            velocity = 0;
            moveAnimCntrl = false;
            tukurAnimCntrl = true;
        }
        transform.position = Vector3.MoveTowards(transform.position, redKing.transform.position, velocity);
    }
}
