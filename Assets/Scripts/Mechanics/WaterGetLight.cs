using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGetLight : MonoBehaviour
{
    private float _subtractedIntencity = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            player.GiveIntensity(_subtractedIntencity);
        }
    }
}
