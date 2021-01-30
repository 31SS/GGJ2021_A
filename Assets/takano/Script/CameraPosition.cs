using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    private GameObject pos;   //オブジェクト情報格納用

    int num = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //次へ
        if (Input.GetKeyDown(KeyCode.Z))
        {
            num++;
            if (num > 5)
            {
                num = 0;
            }
            //参照したオブジェクトのフォーカスを非アクティブ
            pos.GetComponent<PartsController>().isFocus = false;
        }
        //戻る
        else if (Input.GetKeyDown(KeyCode.X))
        {
            num--;
            if (num < 0)
            {
                num=0;
            }
            pos.GetComponent<PartsController>().isFocus = false;
        }
        //プレハブのクローンオブジェクトを参照
        switch (num) 
        {
            case 0: pos = GameObject.Find("rightleg(Clone)"); break;
            case 1: pos = GameObject.Find("leftleg(Clone)"); break;
            case 2: pos = GameObject.Find("lefteye(Clone)"); break;
            case 3: pos = GameObject.Find("righteye(Clone)"); break;
            case 4: pos = GameObject.Find("righthand(Clone)"); break;
            case 5: pos = GameObject.Find("lefthand(Clone)"); break;
            default:
                break;
        }
        //参照したオブジェクトのフォーカスをアクティブ
        pos.GetComponent<PartsController>().isFocus = true;
        //参照したオブジェクトに追従
        this.transform.position =new Vector3(pos.transform.position.x, pos.transform.position.y+8,-10);
    }
}
