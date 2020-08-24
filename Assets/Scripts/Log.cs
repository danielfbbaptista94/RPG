using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : EnemyController
{
    private Rigidbody2D _rigidbody2D;
    public Transform target;
    public Transform homePosition;
    public float chaseRadius;
    public float attackRadius;
    

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    { 
        CheckDistance();
    }

    private void CheckDistance()
    {
        if ( (Vector3.Distance(target.position, transform.position) <= chaseRadius) &&
             (Vector3.Distance(target.position, transform.position) > attackRadius))
        {
            Vector3 temp = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            _rigidbody2D.MovePosition(temp);
        }
    }
}
