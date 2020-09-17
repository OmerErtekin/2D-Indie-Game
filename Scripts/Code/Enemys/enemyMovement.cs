using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    GameObject redKing;
    public float speed;
    void Start()
    {
        redKing = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        //Debug.Log(Vector2.Distance(transform.position, redKing.transform.position));
        if (Vector2.Distance(transform.position, redKing.transform.position) >= 0.05f)
        {
            transform.position = Vector2.MoveTowards(transform.position, redKing.transform.position, speed * Time.deltaTime);
        }
        if(redKing.GetComponent<RedKing>().isAlive == false && !this.CompareTag("rebornWhiteSquareTag"))
        {
            Destroy(gameObject);
        }

    }
}
