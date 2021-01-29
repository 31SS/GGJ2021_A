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

    // Start is called before the first frame update
    void Start()
    {
        
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
                GetComponent<Rigidbody2D>().AddForce(Vector2.right * Speed * dx, ForceMode2D.Force);
            }

            if (canJump)
            {
                if (Input.GetButton("Jump"))
                {
                    if (!isJump)
                    {
                        isJump = true;
                        GetComponent<Rigidbody2D>().AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
                    }
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //仮　床と衝突したらisJumpをfalseにする
        if (collision.gameObject.name == "Floor")
        {
            isJump = false;
        }
    }
}
