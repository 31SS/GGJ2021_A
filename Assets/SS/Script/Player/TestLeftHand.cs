﻿using System.Collections;
using System.Collections.Generic;
using BodyNumber;
using UnityEngine;

public class TestLeftHand : MonoBehaviour, IPickupable
{
    public void PickedUp(PlayerController player)
    {
        player.bodyParts[Define.LEFTHAND].SetActive(true);
        Destroy(gameObject);
    }
}