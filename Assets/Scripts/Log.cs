using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : EnemyController
{
    public Transform target;
    public Transform homePosition;
    public float chaseRadius;
    public float attackRadius;
    

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    { 
        CheckDistance();
    }

    private void CheckDistance()
    {
        if ((Vector3.Distance(target.position, transform.position) > chaseRadius) && (Vector3.Distance(target.position, transform.position) > attackRadius))
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
