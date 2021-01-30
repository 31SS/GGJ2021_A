using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBodyAnimation : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    bool isJump = false;

    bool isRight = false;

    PlayerController pc;

    public GameObject HeadObj;
    public Sprite HeadSprite;
    public Sprite RightHeadSprite;
    public Sprite LeftHeadSprite;
    public Sprite BothHeadSprite;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        pc = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
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
                if (!isRight)
                {
                    //急反転
                    animator.SetTrigger("idle");
                    isRight = true;
                }
                else { 
                    animator.SetTrigger("rightwalk");
                    //顔反転
                    changeGyakuHead();
                    isRight = true;
                }
            }
            else if (rb.velocity.x <= 0.1 && rb.velocity.x >= -0.1)
            {
                animator.SetTrigger("idle");
                //顔反転
                changeGyakuHead();
            }
            else
            {
                if (isRight)
                {
                    //急反転
                    animator.SetTrigger("idle");
                    isRight = false;
                }
                else
                {
                    isRight = false;
                    animator.SetTrigger("leftwalk");
                    changeHead();
                }
            }
        }
        else
        {
            //空中にいる
            if (rb.velocity.x < 0)
            {
                animator.SetTrigger("leftjump");
                changeHead();
            }
            else
            {
                animator.SetTrigger("rightjump");
                //顔反転
                changeGyakuHead();
            }

        }

    }

    void changeHead()
    {
        if (pc.isRightEye)
        {
            if (pc.isLeftEye)
            {
                HeadObj.GetComponent<SpriteRenderer>().sprite = BothHeadSprite;
            }
            else
            {
                HeadObj.GetComponent<SpriteRenderer>().sprite = RightHeadSprite;
            }

        }
        else if(pc.isLeftEye)
        {
            HeadObj.GetComponent<SpriteRenderer>().sprite = LeftHeadSprite;
        }
        else
        {
            HeadObj.GetComponent<SpriteRenderer>().sprite = HeadSprite;
        }

    }

    void changeGyakuHead()
    {
        if (pc.isRightEye)
        {
            if (pc.isLeftEye)
            {
                HeadObj.GetComponent<SpriteRenderer>().sprite = BothHeadSprite;
            }
            else
            {
                HeadObj.GetComponent<SpriteRenderer>().sprite = LeftHeadSprite;
            }

        }
        else if (pc.isLeftEye)
        {
            HeadObj.GetComponent<SpriteRenderer>().sprite = RightHeadSprite;
        }
        else
        {
            HeadObj.GetComponent<SpriteRenderer>().sprite = HeadSprite;
        }

    }

}
