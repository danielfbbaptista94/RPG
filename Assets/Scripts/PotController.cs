using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotController : MonoBehaviour
{
    private Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetSmash()
    {
        _animator.SetBool("smash", true);
    }

}
