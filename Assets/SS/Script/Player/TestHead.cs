using System.Collections;
using System.Collections.Generic;
using BodyNumber;
using UnityEngine;

public class TestHead : MonoBehaviour, IPickupable
{
    public void PickedUp(PlayerController player)
    {
        player.bodyParts[Define.HEAD].SetActive(true);
        Destroy(gameObject);
    }
}
