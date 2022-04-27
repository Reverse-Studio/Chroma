using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float JumpPower;
    public bool IsSliding;
    public int Health;
    private Animator animator;
    private Rigidbody rigid;

    //바닥과의 거리
    public float PlaneDistance
    {
        get
        {
            return planeDistance;
        }
        set
        {
            planeDistance = value;
            animator.SetFloat("PlaneDistance", value);
        }
    }

    public bool IsJumping
    {
        get
        {
            return animator.GetBool("IsJumping");
        }
        set
        {
            animator.SetBool("IsJumping", value);
        }
    }

    public bool IsRunning
    {
        get
        {
            return animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Fast Run";
        }
    }

    private float planeDistance;
    private bool jump;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }


    void Update()
    {
        jump = Input.GetKey(KeyCode.UpArrow);
    }

    void FixedUpdate()
    {
        Distancing();
        DoJump();
    }

    private void Distancing()
    {
        Debug.DrawRay(transform.position, Vector3.down, Color.green, 1f);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            PlaneDistance = hit.distance;
        }
        else
        {
            PlaneDistance = 0f;
            IsJumping = false;
            rigid.velocity = Vector3.zero;
        }
    }

    private void DoJump()
    {
        if (IsRunning && jump && IsJumping == false)
        {
            rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
            IsJumping = true;
        }
    }
}
