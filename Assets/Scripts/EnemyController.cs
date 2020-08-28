using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}

public class EnemyController : MonoBehaviour
{
    public EnemyState state;
    public int health;
    public string enemyName;
    public int baseAttack;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartAnimation(Animator anim, bool valor, bool directionValor, Vector2 direction)
    {
        if (directionValor)
        {
            anim.SetBool("wakeUp", valor);
            ChangeAnimation(anim, direction);
        }
        else
        {
            anim.SetBool("wakeUp", valor);
        }
    }

    private void ChangeAnimation(Animator anim, Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                SetAnimFloat(anim, Vector2.right);
            } else if (direction.x < 0)
            {
                SetAnimFloat(anim, Vector2.left);
            }
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                SetAnimFloat(anim, Vector2.up);
            } else if (direction.y < 0)
            {
                SetAnimFloat(anim, Vector2.down);
            }
        }
    }

    private void SetAnimFloat(Animator anim, Vector2 setVector)
    {
        anim.SetFloat("moveX", setVector.x);
        anim.SetFloat("moveY", setVector.y);
    }
    
}
