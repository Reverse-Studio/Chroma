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

    private float planeDistance;
    private bool jump;
    private bool slide;
    private NoteTypes[] enteredNotes = new NoteTypes[4];

    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }


    void Update()
    {
        jump = Input.GetKeyDown(KeyCode.UpArrow);
        slide = Input.GetKeyDown(KeyCode.DownArrow);
    }

    void FixedUpdate()
    {
        DoJump();
        DoSlide();
    }

    private void DoSlide()
    {
        if (IsRunning && slide && enteredNotes[1] != null)
        {
            Destroy(enteredNotes[1].gameObject);
            enteredNotes[1] = null;
            animator.SetTrigger("DoSlide");
        }
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
        Distancing();

        if (IsRunning && jump && IsJumping == false && enteredNotes[2] != null)
        {
            Destroy(enteredNotes[2].gameObject);
            enteredNotes[2] = null;
            rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
            IsJumping = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("note"))
        {
            NoteTypes types = other.GetComponent<NoteTypes>();
            enteredNotes[types.type] = types;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("note"))
        {
            NoteTypes types = other.GetComponent<NoteTypes>();
            enteredNotes[types.type] = null;
        }
    }
}
