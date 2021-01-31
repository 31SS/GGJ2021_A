using System.Collections;
using System.Collections.Generic;
using BodyNumber;
using UnityEngine;

public class PickedupRightHand: MonoBehaviour, IPickupable
{
    SoundManager sm;

    public void Start()
    {
        sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    public void PickedUp(PlayerController player)
    {
        player.bodyParts[Define.RIGHTHAND].SetActive(true);
        Destroy(gameObject);

        sm.SEPlay("決定、ボタン押下32");
    }
}
