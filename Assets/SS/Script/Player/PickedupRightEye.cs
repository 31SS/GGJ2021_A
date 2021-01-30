using System.Collections;
using System.Collections.Generic;
using BodyNumber;
using UnityEngine;

public class PickedupRightEye : MonoBehaviour, IPickupable
{
    public void PickedUp(PlayerController player)
    {
        if (player.isHead)
        {
            player.bodyParts[Define.RIGHTEYE].SetActive(true);
            player.isRightEye = true;
            Destroy(gameObject);
        }
    }
}
