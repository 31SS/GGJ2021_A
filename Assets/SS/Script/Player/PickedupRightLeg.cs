using System.Collections;
using System.Collections.Generic;
using BodyNumber;
using UnityEngine;

public class PickedupRightLeg : MonoBehaviour, IPickupable
{

    SoundManager sm;

    public void Start()
    {
        sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    public void PickedUp(PlayerController player)
    {
        player.bodyParts[Define.RIGHTLEG].SetActive(true);
        player.isLeg = true;
        player.GetComponent<MainBodyAnimation>().GetLeg();
        Destroy(gameObject);

        sm.SEPlay("決定、ボタン押下32");

    }
}
