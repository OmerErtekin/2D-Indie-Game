using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spitleMouvement : MonoBehaviour
{
    GameObject redKing;
    void Start()
    {
        redKing = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        mouve();
    }

    void mouve()
    {
        //Vector3 direction;
        //direction = (redKing.transform.position - transform.position).normalized;

        transform.position = Vector3.MoveTowards(transform.position,redKing.transform.position,0.3f);

        if (Vector2.Distance(transform.position, redKing.transform.position) < 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
