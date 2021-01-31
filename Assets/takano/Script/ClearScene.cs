using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearScene : MonoBehaviour
{
    GameObject hair;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Body"))
        {
            //hairにBodyを格納
            hair = GameObject.FindGameObjectWithTag("Body");

            //isHairがtrue
            if (hair.GetComponent<PlayerController>().isHead == true)
            {
                if (hair.GetComponent<PlayerController>().isHair == true)
                {
                    if (hair.GetComponent<PlayerController>().isLeftEye == true || hair.GetComponent<PlayerController>().isRightEye == true)
                    {
                        //GameClearシーンへ
                        SceneManager.LoadScene("GameClear1");
                    }
                }
                else if (hair.GetComponent<PlayerController>().isHair == false)
                {
                    SceneManager.LoadScene("GameClear2");
                }
                if (hair.GetComponent<PlayerController>().isLeftEye == false || hair.GetComponent<PlayerController>().isRightEye == false)
                {
                    //GameClearシーンへ
                    SceneManager.LoadScene("GameClear2");
                }
                if (hair.GetComponent<PlayerController>().isLeftEye == true && hair.GetComponent<PlayerController>().isRightEye == true)
                {
                    if (hair.GetComponent<PlayerController>().isHair == true)
                    {
                            SceneManager.LoadScene("GameClear1");
                    }
                    else
                    {
                        //GameClearシーンへ
                        SceneManager.LoadScene("GameClear2");
                    }
                }

            }
            else if (hair.GetComponent<PlayerController>().isHead == false)
            {

            }
        }

    }
}
