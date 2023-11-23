using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointFillLight : MonoBehaviour
{
    private float _intencity = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            player.AddIntensity(_intencity);
            Destroy(gameObject);
        }
    }
}
