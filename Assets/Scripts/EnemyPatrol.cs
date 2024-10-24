using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public List<Vector3> waypoints;
    private int speed = 4;
    private int num;
    private enum states
    {
        Patrol,
        Chase
    }

    private states state;
    private float timer;
    private GameObject target;
    private Vector3 targetpos;
    public TopDown_EnemyAnimator _controller;


    void Start()
    {
        _controller = GetComponent<TopDown_EnemyAnimator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("detected");
        if (other.gameObject.CompareTag("Player"))
        {
            target = other.GameObject();
            state = states.Chase;
            timer = 10;
        }
    }
    
    
    
    
    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            targetpos = target.transform.position;
        }

        if (state == states.Patrol)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[num], 2 * Time.deltaTime);
            if (transform.position == waypoints[num])
            {
                num += 1;
                if (num > 2)
                {
                    num = 0;
                }
            }
            
           
            
        }

        if (state == states.Chase && Vector3.Distance(transform.position, target.transform.position) < 1)
        {
            Attack();
        }

        if (state == states.Chase)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                state = states.Patrol;
            }
            transform.position = Vector3.MoveTowards(transform.position, targetpos, 2 * Time.deltaTime);
        }
    }
    
    public void Attack()
    {
        _controller.Attack();
    }
}
