using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class TurretCode : MonoBehaviour
{
    private float cooldown;
    private float firerate;
    public GameObject fireballPrefab;
   
    void Start()
    {
        
    } 

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && cooldown < 0)
        {
            //create a clone of the fireballPrefab
            GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity); 
            //get the clone's script
            EnemyFireball enemyFireball = fireball.GetComponent<EnemyFireball>();
            //set the target on the clones script
            enemyFireball.targetPosition = other.transform.position;

            cooldown = 2;
        }
    }


    // Update is called once per frame
    void Update()
    {
       cooldown -= Time.deltaTime;
    }
}
