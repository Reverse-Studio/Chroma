using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float JumpPower;
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

    public bool IsRolling
    {
        get
        {
            return animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Rolling";
        }
    }

    private float planeDistance;
    private bool jump;
    private bool roll;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }


    void Update()
    {
        jump = Input.GetKey(KeyCode.UpArrow);
        roll = Input.GetKey(KeyCode.DownArrow);
    }

    void FixedUpdate()
    {
        animator.ResetTrigger("DoSlide");
        Distancing();

        DoJump();
        DoRoll();
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
        if (IsRunning && jump && !IsJumping && !IsRolling)
        {
            rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
            IsJumping = true;
        }
    }

    private void DoRoll()
    {
        if (IsRunning && roll && !IsRolling && !IsJumping)
        {
            animator.SetTrigger("DoSlide");
            Debug.Log("ROLL!");
        }
    }
}