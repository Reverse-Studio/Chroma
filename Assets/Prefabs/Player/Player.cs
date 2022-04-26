using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool IsSliding;
    public int Health;

    private Animator animator;
    public float FloatingTime
    {
        get
        {
            return animator.GetFloat("FloatingTime");
        }
        set
        {
            animator.SetFloat("FloatingTime", value);
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        timing();

        if (Input.anyKeyDown) doJump();
    }

    public void doJump()
    {
        if (FloatingTime < 0)
        {
            FloatingTime = 2;
        }
    }
    private void timing()
    {
        if (FloatingTime >= 0)
        {
            FloatingTime -= Time.deltaTime;
        }
    }
}
