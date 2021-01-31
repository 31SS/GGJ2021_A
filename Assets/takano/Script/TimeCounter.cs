using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeCounter : MonoBehaviour
{
    float time;  //時間設定
    int minute;
    public Text timeText;   //テキスト表示

    // Start is called before the first frame update
    void Start()
    {
        minute = 7;
    }

    // Update is called once per frame
    void Update()
    {
        //時間
        time += Time.deltaTime;
        if (time　>　20f)
        {
            minute--;
            time = 0f;
        }
        //時間表示
        timeText.text ="朝まであと:"+minute.ToString("") + "時間";
        if (minute <= 0f)
        {
            timeText.text = "朝になりました";

            //GameOverのリザルト画面へ
            SceneManager.LoadScene("GameOver");
        }
    }
}
