using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartManager : MonoBehaviour
{
    public GameObject[] parts; //アイテムプレハブ
    public GameObject[] spawnPoints;　//スポーン位置
    public GameObject part;
    public GameObject body;
    private void Awake()
    {
        //パーツの順番をシャッフル
        Shuffle(parts);
        for (int i = 0; i < parts.Length; i++)
        {
            Instantiate(parts[i], spawnPoints[i].transform.position, transform.rotation);
        }
        Instantiate(part, new Vector3(50, 0, 0), transform.rotation);
        Instantiate(body, new Vector3(0, 0, 0), transform.rotation);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
