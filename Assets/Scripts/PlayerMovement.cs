using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D _rigidbody2D;
    private Vector3 _vector3;
    private Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _vector3 = Vector3.zero;
        _vector3.x = Input.GetAxisRaw("Horizontal");
        _vector3.y = Input.GetAxisRaw("Vertical");

        UpdateAnimationAndMove();
    }

    void Move()
    {
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
    
}
