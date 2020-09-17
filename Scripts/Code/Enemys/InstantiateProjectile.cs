using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateProjectile : MonoBehaviour
{
    public GameObject projectile;
    public AudioSource shootSound;

    public static bool projectileCntrl = false; // shot butonuna basılınca bu true olur ve if icine girer.

    void Update()
    {

        if (projectileCntrl)
        {
            shootSound.Play();
            Instantiate(projectile, transform.position, Quaternion.identity); // kursun urettik
            projectileCntrl = false;

        }
    }

   
}
