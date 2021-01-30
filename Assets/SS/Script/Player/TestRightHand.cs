using System.Collections;
using System.Collections.Generic;
using BodyNumber;
using UnityEngine;

public class TestRightHand: MonoBehaviour, IPickupable
{
    public void PickedUp(PlayerController player)
    {
        player.bodyParts[Define.RIGHTHAND].SetActive(true);
        Destroy(gameObject);
    }
}
