using System.Collections;
using System.Collections.Generic;
using BodyNumber;
using UnityEngine;

public class PickedupHair : MonoBehaviour, IPickupable
{
    public void PickedUp(PlayerController player)
    {
        if (player.isHead)
        {
            player.bodyParts[Define.HAIR].SetActive(true);
            Destroy(gameObject);
            player.isHair = true;
            Destroy(gameObject);
        }
    }
}
