using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameManager gm;

    
    // Start is called before the first frame update
    void Start()
    {
        gm = FindFirstObjectByType<GameManager>();
    }

    void OnCollisionStay2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Spikes"))
        {
            gm.ChangeHealth(-2);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            gm.ChangeHealth(-2);
        }
    } 
}

   