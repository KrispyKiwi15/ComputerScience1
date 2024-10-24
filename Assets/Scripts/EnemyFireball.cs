using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireball : MonoBehaviour
{
    private float timer;
    public Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        timer = 1;
        Vector3.MoveTowards(transform.position, targetPosition, 2 * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Destroy(gameObject);
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, 20 * Time.deltaTime);
    }
}
