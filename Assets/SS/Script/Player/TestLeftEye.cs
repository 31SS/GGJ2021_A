﻿using System.Collections;
using System.Collections.Generic;
using BodyNumber;
using UnityEngine;

public class TestLeftEye : MonoBehaviour, IPickupable
{
    public void PickedUp(PlayerController player)
    {
        player.bodyParts[Define.LEFTEYE].SetActive(true);
        Destroy(gameObject);
    }
}
