using System.Collections;
using System.Collections.Generic;
using BodyNumber;
using UnityEngine;

public class PickedupRightEye : MonoBehaviour, IPickupable
{

    SoundManager sm;

    public void Start()
    {
        sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    public void PickedUp(PlayerController player)
    {
        if (player.isHead)
        {
            player.bodyParts[Define.RIGHTEYE].SetActive(true);
            player.isRightEye = true;
            Destroy(gameObject);

            sm.SEPlay("決定、ボタン押下32");

        }
    }
}
