using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    interact
}

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public PlayerState state;
    
    private Rigidbody2D _rigidbody2D;
    private Vector3 _vector3;
    private Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        state = PlayerState.walk;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        
        _animator.SetFloat("moveX", 0);
        _animator.SetFloat("moveY", -1);
    }

    // Update is called once per frame
    void Update()
    {
        _vector3 = Vector3.zero;
        _vector3.x = Input.GetAxisRaw("Horizontal");
        _vector3.y = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Attack") && (state != PlayerState.attack))
        {
            StartCoroutine(AttackCoroutine());
        }
        else if (state == PlayerState.walk)
        {
            UpdateAnimationAndMove();
        }
    }

    void Move()
    {
        _vector3.Normalize();
        _rigidbody2D.MovePosition(transform.position + (_vector3 * speed * Time.deltaTime));
    }

    void UpdateAnimationAndMove()
    {
        if (_vector3 != Vector3.zero)
        {
            Move();
            _animator.SetFloat("moveX", _vector3.x);
            _animator.SetFloat("moveY", _vector3.y);
            _animator.SetBool("isMoving", true);
        }
        else
        {
            _animator.SetBool("isMoving", false);
        }
    }

    private IEnumerator AttackCoroutine()
    {
        _animator.SetBool("isAttacking", true);
        state = PlayerState.attack;
        yield return null; // WAIT 1 FRAME
        
        _animator.SetBool("isAttacking", false);
        yield return new WaitForSeconds(.3f);
        
        state = PlayerState.walk;
    }
}
