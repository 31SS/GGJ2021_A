using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadarController : MonoBehaviour
{

    //両目・両手・両足・髪の毛　で7つ
    GameObject[] gObj = new GameObject[7];
    string[] gObjName = new string[7]
    {
        "lefteye(Clone)",
        "righteye(Clone)",
        "leftleg(Clone)",
        "rightleg(Clone)",
        "lefthand(Clone)",
        "righthand(Clone)",
        "hair(Clone)",
    };
    GameObject bodyObj; //体は特別
    GameObject goalObj; //ゴール
    string goalObjName = "bed";
    string bodyObjName = "MainWholeBody(Clone)";

    public GameObject[] ladarmark = new GameObject[7];
    public GameObject bodymark;
    public GameObject goalmark;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 7; i++)
        {
            gObj[i] = GameObject.Find(gObjName[i]);
            if (!gObj[i])
            {
                Debug.Log(gObjName[i] + " is Missing");
            }
        }
        goalObj = GameObject.Find(goalObjName);
        if (!goalObj)
        {
            Debug.Log(goalObjName + " is Missing");
        }
        bodyObj = GameObject.Find(bodyObjName);
        if (!bodyObj)
        {
            Debug.Log(goalObjName + " is Missing");
        }

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 kyori;

        //ゴールの位置
        kyori = goalObj.transform.position-this.transform.position;
        //Debug.Log(kyori);
        goalmark.GetComponent<RectTransform>().anchoredPosition = kyori*5f;

        //体の位置
        if (this.gameObject.name==bodyObjName)
        {
            bodymark.SetActive(false);
        }
        else
        {
            bodymark.SetActive(true);
            kyori = bodyObj.transform.position - this.transform.position;
            bodymark.GetComponent<RectTransform>().anchoredPosition = kyori * 5f;
        }

        for (int i = 0; i < 7; i++)
        {
            if (!gObj[i]) {
                //すでに取得した(Destroy)されたのでladarmarkを非表示
                ladarmark[i].SetActive(false);
            }
            else
            {
                kyori = gObj[i].transform.position - this.transform.position;
                //Debug.Log(kyori);
                ladarmark[i].GetComponent<RectTransform>().anchoredPosition = kyori * 5f;
            }
        }
    }
}
