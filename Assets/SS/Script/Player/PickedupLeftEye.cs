using System.Collections;
using System.Collections.Generic;
using BodyNumber;
using UnityEngine;

public class PickedupLeftEye : MonoBehaviour, IPickupable
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
            player.bodyParts[Define.LEFTEYE].SetActive(true);
            player.isLeftEye = true;
            Destroy(gameObject);

            sm.SEPlay("決定、ボタン押下32");

        }
    }
}
