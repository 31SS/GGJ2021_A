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

    BoxCollider2D bc;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        pc = GetComponent<PlayerController>();

        //当たり判定　服の位置
        bc = GetComponent<BoxCollider2D>();
        bc.offset = new Vector2(0f,-2.5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dx = Input.GetAxis("Horizontal");
        float dy = Input.GetAxis("Vertical");


        Debug.Log(bc.offset.y);
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

    public void GetLeg()
    {
        //ボディを上に動かす（でないと床をすり抜けてします）
        transform.Translate(Vector2.up * 3);
        //当たり判定を足の位置に
        bc.offset = new Vector2(0f, -4.5f);
    }
}
