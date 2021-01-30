using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsController : MonoBehaviour
{
    public float Speed=20.0f;
    public float JumpForce=5.0f;
    public bool canJump = false; //ジャンプできるオブジェクトはtrueにする ※基本すべてジャンプできる
    public bool isFocus = false; //選択してる時だけ動く
    bool isJump = false;

    Animator animator;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isFocus)
        {
            float dx = Input.GetAxis("Horizontal");
            float dy = Input.GetAxis("Vertical");

            //空中でなければ、横移動する
            if (!isJump)
            {
                //transform.Translate(dx * Speed, 0.0F, 0.0F);
                rb.AddForce(Vector2.right * Speed * dx, ForceMode2D.Force);
                if (rb.velocity.x > 0.1)
                {
                    animator.SetTrigger("rightwalk");
                }else if (rb.velocity.x < 0.1 && rb.velocity.x > -0.1)
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

            if (canJump)
            {
                if (Input.GetButton("Jump"))
                {
                    if (!isJump)
                    {
                        isJump = true;
                        rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
                    }
                }
            }

            Debug.Log("isJump " + isJump);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //仮　床と衝突したらisJumpをfalseにする
        if (collision.gameObject.name == "Floor")
        {
            isJump = false;
            animator.SetTrigger("idle");
        }
    }
}
