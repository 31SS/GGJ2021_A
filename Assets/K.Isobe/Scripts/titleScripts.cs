using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScripts : MonoBehaviour
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

            SceneManager.LoadScene("mainScene");

        }

        if (Input.GetKeyDown(KeyCode.Z))
        {

            Quit();

        }

    }

    public void play()
    {

        SceneManager.LoadScene("mainScene");

    }

    public void Quit()
    {

        UnityEngine.Application.Quit();

    }

    public void loadCreditDown()
    {

        SceneManager.LoadScene("Credit");

    }

}
