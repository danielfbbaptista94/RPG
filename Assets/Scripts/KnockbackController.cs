using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class KnockbackController : MonoBehaviour
{
    public float thrust;
    public float timer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D _rigidbody2D = other.GetComponent<Rigidbody2D>();

            if (_rigidbody2D != null)
            {
                _rigidbody2D.GetComponent<EnemyController>().state = EnemyState.stagger;
                StartCoroutine(KnockCorrotine(_rigidbody2D));
            }
        }
    }

    private IEnumerator KnockCorrotine(Rigidbody2D r2D)
    {
        Vector2 difference = r2D.transform.position - transform.position;
        Vector2 force = difference.normalized * thrust;

        r2D.velocity = force;
        yield return new WaitForSeconds(timer);
        
        r2D.velocity = new Vector2();
        r2D.GetComponent<EnemyController>().state = EnemyState.idle;
    }
    
}
