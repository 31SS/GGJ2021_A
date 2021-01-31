using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    bool flag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //escキーでポーズメニューを非アクティブ
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);

        }
    }
    //続けるボタン
    public void ClickReturn()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
    //はじめからボタン
    public void ClickRetry()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("mainScene");
        Time.timeScale = 1f;
    }
    //タイトルへ
    public void ClickTitle()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("Title");
        Time.timeScale = 1f;
    }
}
