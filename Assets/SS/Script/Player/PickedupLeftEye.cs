﻿using System.Collections;
using System.Collections.Generic;
using BodyNumber;
using UnityEngine;

public class PickedupLeftEye : MonoBehaviour, IPickupable
{
    public void PickedUp(PlayerController player)
    {
        if (player.isHead)
        {
            player.bodyParts[Define.LEFTEYE].SetActive(true);
            player.isLeftEye = true;
            Destroy(gameObject);
        }
    }
}
