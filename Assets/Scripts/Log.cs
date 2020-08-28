using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : EnemyController
{
    private Rigidbody2D _rigidbody2D;
    private Transform target;
    public Transform homePosition;
    private Animator _animator;
    public float chaseRadius;
    public float attackRadius;
    

    void Start()
    {
        state = EnemyState.idle;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        CheckDistance();
    }

    private void CheckDistance()
    {
        if ( (Vector3.Distance(target.position, transform.position) <= chaseRadius) &&
             (Vector3.Distance(target.position, transform.position) > attackRadius) &&
             (state == EnemyState.idle || state == EnemyState.walk))
        {
            Vector3 temp = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            _rigidbody2D.MovePosition(temp);
            ChageState(EnemyState.walk);
            StartAnimation(_animator, true, true, (temp - transform.position));
        }
        else
        {
            StartAnimation(_animator, false, false, (transform.position));
        }
    }

    private void ChageState(EnemyState newState)
    {
        if (state != newState)
        {
            state = newState;
        }
    }
}
