using System.Collections;
using System.Collections.Generic;
using BodyNumber;
using UnityEngine;

public class PickedupLeftLeg : MonoBehaviour, IPickupable
{
    public void PickedUp(PlayerController player)
    {
        player.bodyParts[Define.LEFTLEG].SetActive(true);
        player.isLeg = true;
        player.GetComponent<MainBodyAnimation>().GetLeg();
        Destroy(gameObject);
    }
}
