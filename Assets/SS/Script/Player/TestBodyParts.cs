using System.Collections;
using System.Collections.Generic;
using BodyNumber;
using UnityEngine;

public class TestBodyParts : MonoBehaviour, IPickupable
{
    public void PickedUp(PlayerController player)
    {
        player.bodyParts[Define.RIGHTLEG].SetActive(true);
        Destroy(gameObject);
    }
}
