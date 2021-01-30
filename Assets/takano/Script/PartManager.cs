using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartManager : MonoBehaviour
{
    public GameObject[] parts; //アイテムプレハブ
    public GameObject[] spawnPoints;　//スポーン位置

    public GameObject camera;
    int num=0;
    // Start is called before the first frame update
    void Start()
    {
        //パーツの順番をシャッフル
        Shuffle(parts);
        for (int i = 0; i < 7; i++)
        {
            Instantiate(parts[i], spawnPoints[i].transform.position, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            num++;
            if (num > 6)
            {
                num = 0;
            }
        }
        Debug.Log(num);
        camera.transform.position= new Vector3(parts[num].transform.position.x, 0, -10);
    }
 
    void Shuffle(GameObject[] num)
    {
        for (int i = 0; i < num.Length; i++)
        {
            //現在の要素を預けておく
            GameObject temp = num[i];
            //入れ替える先をランダムに選ぶ
            int randomIndex = Random.Range(0, num.Length);
            //現在の要素に上書き
            num[i] = num[randomIndex];
            //入れ替え元に預けておいた要素を与える
            num[randomIndex] = temp;
        }
    }
}
