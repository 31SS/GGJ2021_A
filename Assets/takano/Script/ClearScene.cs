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
            if (hair.GetComponent<PlayerController>().isHair == true)
            {
                //GameClearシーンへ
                SceneManager.LoadScene("GameClear1");
            }
            else if (hair.GetComponent<PlayerController>().isHair == false)
            {
                //GameClearシーンへ
                SceneManager.LoadScene("GameClear2");
            }
        }

    }
}
