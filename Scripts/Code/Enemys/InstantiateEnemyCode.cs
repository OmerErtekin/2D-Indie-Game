using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InstantiateEnemyCode : MonoBehaviour
{
    public GameObject blackCircleEnemy;
    public GameObject spawnEnemy;
    public GameObject blackSquareSpawnEnemy;
    public GameObject whiteSquareSpawnEnemy;
    public GameObject spitleEnemy;

    private float coolDown = 15f;
    private float nextLevelTime = 15;
    
    knocker knocker;

    Vector3 create;
    Vector3 create2;
    Vector3 create3;

    float timer = 0;
    float timer_2 = 0;
    float timer_3 = 0;
    float timer_4 = 0;
    float timer_5 = 0;

    //black circle
    float oneUp = 3f;
    float oneDown = 5f;

    //virus
    float twoUp = 4f;
    float twoDown = 6f;

    //spawn
    float threeUp = 3f;
    float threeDown = 5f;

    //spitle
    float fourUp = 11f;
    float fourDown = 16f;

    // white
    float fiveUp = 14f;
    float fiveDown = 24f;
    int timeWhite = 0;

    bool enemyOne = true;
    bool enemyTwo = true;
    bool enemyThree = true;

    float motherTime = 0;

    public AudioSource audioSource;


    void Start()
    {
        
    }

    void FixedUpdate()
    {
        randomCreat();
        //*************************
        timer -= Time.deltaTime;
        timer_2 -= Time.deltaTime;
        timer_3 -= Time.deltaTime;
        timer_4 -= Time.deltaTime;
        timer_5 -= Time.deltaTime;
        motherTime += Time.deltaTime;


        if(motherTime > nextLevelTime)
        {

            motherTime = 0;
            if(timer >= 0.1f)
            {
                timer /= 1.25f;
            }
            if(timer_2 >= 0.1f)
            {
                timer_2 /= 1.1f;
            }
            if (timer_3 >= 0.1f && !enemyOne)
            {
                timer_3 /= 1.1f;
            }
            if(timer_4 >= 0.1f && knocker.newEnemyCount > 65)
            {
                timer_4 /= 1.1f;
            }
            if(timer_5 >= 0.1f)
            {
                timer_5 /= 0.75f;
            }
           
        }

        //*************************
        // BLACK CIRCLE
        if (timer < 0.5f)
        {

            Instantiate(blackCircleEnemy, create, Quaternion.identity);
            timer = 0;
            timer = Random.Range(oneUp, oneDown);

            randomCreat();
        }
        // BLACK SQUARE
        if (knocker.newEnemyCount > Random.Range(13,18)) 
        {
            if (enemyOne)
            {
                oneUp = 3.5f;
                oneDown = 4.5f;
            }

            if (timer_2 < 0.5f)
            {
                newEnemyPos();
                timer_2 = 0;
                timer_2 = Random.Range(twoUp, twoDown);
                Instantiate(spawnEnemy, create2, Quaternion.identity);
            }
        }
        // ENEMY SPAWN
        if (knocker.newEnemyCount > Random.Range(30,40))
        {
            enemyOne = false;

            if (enemyTwo)
            {
                twoUp = 2f;
                twoDown = 3f;

                oneUp = 4f;
                oneDown = 6f;
            }

            if (timer_3 < 0.5f)
            {
                newEnemyPos();
                timer_3 = 0;
                timer_3 = Random.Range(threeUp, threeDown);
                Instantiate(blackSquareSpawnEnemy, create2, Quaternion.identity);
            }
            audioSource.pitch = 1.01f;
        }
        // ENEMY SPITLE
        if (knocker.newEnemyCount > Random.Range(45,55))
        {
            enemyTwo = false;
            if (enemyThree)
            {
                twoUp = 3f;
                twoDown = 5f;

                threeUp = 2.5f;
                threeDown = 3.5f;
            }

            if (timer_4 < 0.5f)
            {
                spitleEnemyCreatPos();

                timer_4 = 0;
                timer_4 = Random.Range(fourUp, fourDown);
                Instantiate(spitleEnemy, create3, Quaternion.identity);
            }

            audioSource.pitch = 1.02f;
        }

        if (knocker.newEnemyCount > Random.Range(15,18))
        {

            if (timer_5 < 0.5f)
            {
                newEnemyPos();
                timer_5 = 0;
                timer_5 = Random.Range(fiveUp, fiveDown);
                Instantiate(whiteSquareSpawnEnemy, create2, Quaternion.identity);
            }
        }

        if(knocker.newEnemyCount > 100)
        {
            enemyThree = false;
            nextLevelTime = 10;

            fourUp = 6;
            fourDown = 8;
            audioSource.pitch = 1.03f;
        }


    }

    //------RANDOM CREATE JUST FOR ENEMY BLACK CIRCLE IN BEGINNING------------//
    private void randomCreat()
    {
        float R;
    //----------------------X-------------------------------------------------
        R = Random.Range(0, 2);
        //Debug.Log(R);

        if (R == 0)
        {
            create.x = Random.Range(8.1f, 6.1f);
            create.z = 0;
        }
       
    else if (R == 1)
        {
            create.x = Random.Range(-8.1f, -6.1f);
            create.z = 0;
        }
    //---------------------Y--------------------------------------------------
        R = Random.Range(0, 2);

        if (R == 1)
        {
            create.y = Random.Range(4.3f, 2.3f);
            create.z = 0;
        }

        else if (R == 0)
        {
            create.y = Random.Range(-4.3f, -2.3f);
            create.z = 0;
        }

    }

    //-----------------------CREATE RANDOM POSİTİON-------------------------------//
    private void newEnemyPos()
    {
        
            int R_2;
            R_2 = Random.Range(0, 5);
        //--------------------LEFT-----------------------
            if(R_2 == 1)
            {
                create2.x = Random.Range(-7,-9);
                create2.y = Random.Range(4,-4);
                create2.z = 0;
            }
        //---------------------UP------------------------

            if (R_2 == 2)
            {
                create2.x = Random.Range(-8.5f, 8.5f);
                create2.y = Random.Range(4.3f,3.7f );
                create2.z = 0;
            }
        //--------------------DOWN------------------------

            if (R_2 == 3)
            {
                create2.x = Random.Range(-8.5f, 8.5f);
                create2.y = Random.Range(-4.3f, -3.7f);
                create2.z = 0;
            }
        //--------------------RIGHT-----------------------

            if (R_2 == 4)
            {
                create2.x = Random.Range(9, 7);
                create2.y = Random.Range(4, -4);
                create2.z = 0;
            }
        }

    private void spitleEnemyCreatPos()
    {
        float R;
        R = Random.Range(0, 2);
        //Debug.Log(R);

        if (R == 0)
        {
            create3.x = Random.Range(8.5f, 7f);
            create3.y = Random.Range(4.3f, 2.3f);
            create3.z = 0;
        }

        else if (R == 1)
        {
            create3.x = Random.Range(-8.5f, -7f);
            create3.y = Random.Range(4.3f, 2.3f);
            create3.z = 0;
        }
    }

}
