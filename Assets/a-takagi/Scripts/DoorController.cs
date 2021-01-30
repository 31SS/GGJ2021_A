using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject DoorOpenObj;
    public GameObject DoorCloseObj;

    // Start is called before the first frame update
    void Start()
    {
        DoorClose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoorOpen()
    {
        DoorOpenObj.SetActive(true);
        DoorCloseObj.SetActive(false);
    }
    public void DoorClose()
    {
        DoorOpenObj.SetActive(false);
        DoorCloseObj.SetActive(true);
    }
}
