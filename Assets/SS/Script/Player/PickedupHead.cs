using System.Collections;
using System.Collections.Generic;
using BodyNumber;
using UnityEngine;

public class PickedupHead : MonoBehaviour, IPickupable
{

    SoundManager sm;

    public void Start()
    {
        sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    public void PickedUp(PlayerController player)
    {
        player.bodyParts[Define.HEAD].SetActive(true);
        player.isHead = true;
        Destroy(gameObject);

        sm.SEPlay("決定、ボタン押下32");

    }
}
