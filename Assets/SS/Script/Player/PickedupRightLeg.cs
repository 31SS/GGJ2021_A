using System.Collections;
using System.Collections.Generic;
using BodyNumber;
using UnityEngine;

public class PickedupRightLeg : MonoBehaviour, IPickupable
{
    public void PickedUp(PlayerController player)
    {
        player.bodyParts[Define.RIGHTLEG].SetActive(true);
        player.isLeg = true;
        player.GetComponent<MainBodyAnimation>().GetLeg();
        Destroy(gameObject);
    }
}
