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
            if (num > 6)
            {
                num = 0;
            }
            //参照したオブジェクトのフォーカスを非アクティブ
            //パーツ
            if (pos.GetComponent<PartsController>() != null)
            {
                pos.GetComponent<PartsController>().isFocus = false;
            }
            //ボディ
            if (pos.GetComponent<PlayerController>() != null)
            {
                pos.GetComponent<PlayerController>().isFocus = false;
            }
        }
        //戻る
        else if (Input.GetKeyDown(KeyCode.X))
        {
            num--;
            if (num < 0)
            {
                num=0;
            }
            //参照したオブジェクトのフォーカスを非アクティブ
            //パーツ
            if (pos.GetComponent<PartsController>() != null)
            {
                pos.GetComponent<PartsController>().isFocus = false;
            }
            //ボディ
            if (pos.GetComponent<PlayerController>() != null)
            {
                pos.GetComponent<PlayerController>().isFocus = false;
            }
        }
        //プレハブのクローンオブジェクトを参照
        switch (num) 
        {
            case 0: pos = GameObject.Find("MainWholeBody(Clone)"); break;
            case 1: if(GameObject.Find("rightleg(Clone)")!=null)pos = GameObject.Find("rightleg(Clone)"); break;
            case 2: if (GameObject.Find("leftleg(Clone)") != null) pos = GameObject.Find("leftleg(Clone)"); break;
            case 3: if (GameObject.Find("lefteye(Clone)") != null) pos = GameObject.Find("lefteye(Clone)"); break;
            case 4: if (GameObject.Find("righteye(Clone)") != null) pos = GameObject.Find("righteye(Clone)"); break;
            case 5: if (GameObject.Find("righthand(Clone)") != null) pos = GameObject.Find("righthand(Clone)"); break;
            case 6: if (GameObject.Find("lefthand(Clone)") != null) pos = GameObject.Find("lefthand(Clone)"); break;
            default:
                
                break;
        }

        //posがdestoryされたら
        if (pos==null)
        {
            //ボディにうつる
            pos = GameObject.Find("MainWholeBody(Clone)");
        }

        //参照したオブジェクトのフォーカスをアクティブ
        //パーツ
        if (pos.GetComponent<PartsController>() != null)
        {
            pos.GetComponent<PartsController>().isFocus = true;
        }
        //ボディ
        if (pos.GetComponent <PlayerController>() != null)
        {
            pos.GetComponent<PlayerController>().isFocus = true;
        }
        
        //参照したオブジェクトに追従
        this.transform.position = new Vector3(pos.transform.position.x, pos.transform.position.y+5, -10);
        
    }
}
