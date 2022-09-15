using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlayerControllerNew : MonoBehaviour
{
    public Main main;

    [SerializeField] public Rigidbody _rigidbody;
    [SerializeField] public FixedJoystick _joystick;
    [SerializeField] public float _moveSpeed = 1;
    public Animator animator;

    public bool onGround;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
            _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed * Time.deltaTime,
                                              _rigidbody.velocity.y * Time.deltaTime * 45f,
                                              _joystick.Vertical * _moveSpeed * Time.deltaTime);
        

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }
    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            onGround = false;
        }
            
    }

    

}
