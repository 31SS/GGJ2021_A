using System.Collections;
using System.Collections.Generic;
using BodyNumber;
using UnityEngine;

public class TestRightEye : MonoBehaviour, IPickupable
{
    public void PickedUp(PlayerController player)
    {
        player.bodyParts[Define.RIGHTEYE].SetActive(true);
        Destroy(gameObject);
    }
}
