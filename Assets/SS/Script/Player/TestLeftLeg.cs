using System.Collections;
using System.Collections.Generic;
using BodyNumber;
using UnityEngine;

public class TestLeftLeg : MonoBehaviour, IPickupable
{
    public void PickedUp(PlayerController player)
    {
        player.bodyParts[Define.LEFTLEG].SetActive(true);
        Destroy(gameObject);
    }
}
