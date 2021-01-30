using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver1Scripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {

            SceneManager.LoadScene("Title");

        }

        if (Input.GetKeyDown(KeyCode.R))
        {

            SceneManager.LoadScene("mainScene");

        }

    }

    public void loadTitleDown()
    {

        SceneManager.LoadScene("Title");

    }

    public void loadPlaySceneDown()
    {

        SceneManager.LoadScene("mainScene");

    }

}