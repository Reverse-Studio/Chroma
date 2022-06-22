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
    public float speed;
    public Vector3[] ways;
    private Queue<Vector3> waypoint;

    private Vector3 point;

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

        waypoint = new Queue<Vector3>();

        foreach (Vector3 way in ways)
        {
            waypoint.Enqueue(way);
        }

        point = waypoint.Dequeue();
    }


    void Update()
    {
        jump = Input.GetKey(KeyCode.UpArrow);
        roll = Input.GetKey(KeyCode.DownArrow);

        float distance = Distance(transform.position, point);

        if (distance < 1)
        {
            if (waypoint.Count != 0)
            {
                point = waypoint.Dequeue();
            }
        }

        Vector3 to = transform.position - point;
        to.y = 0;
        to.Normalize();

        float y = Mathf.Atan2(to.x, to.z) * Mathf.Rad2Deg - 180;

        transform.rotation = Quaternion.Euler(0, y, 0);

        to *= speed * Time.deltaTime;
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private float Distance(Vector3 from, Vector3 to)
    {
        float x = from.x - to.x;
        float z = from.z - to.z;

        return Mathf.Sqrt(x * x + z * z);
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
        Debug.DrawRay(transform.position, Vector3.down, Color.green, 0.1f);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 100f, LayerMask.GetMask("MiniMap")))
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
        }
    }
}