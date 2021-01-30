using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBodyAnimation : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    bool isJump = false;

    PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        pc = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        float dx = Input.GetAxis("Horizontal");
        float dy = Input.GetAxis("Vertical");

        Debug.Log(rb.velocity.x);
        isJump = !pc.m_isGround;
        //空中でなければ、横移動する
        if (!isJump)
        {
            //transform.Translate(dx * Speed, 0.0F, 0.0F);
         //rb.AddForce(Vector2.right * Speed * dx, ForceMode2D.Force);
            if (rb.velocity.x > 0.1)
            {
                animator.SetTrigger("rightwalk");
            }
            else if (rb.velocity.x < 0.1 && rb.velocity.x > -0.1)
            {
                animator.SetTrigger("idle");
            }
            else
            {
                animator.SetTrigger("leftwalk");
            }
        }
        else
        {
            //空中にいる
            if (rb.velocity.x < 0)
            {
                animator.SetTrigger("leftjump");
            }
            else
            {
                animator.SetTrigger("rightjump");
            }

        }

    }

}
