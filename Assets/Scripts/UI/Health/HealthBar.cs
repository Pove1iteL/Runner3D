using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Heart _heartTemplate;

    private List<Heart> _hearts = new List<Heart>();

    private void OnEnable()
    {
        _player.HealthChanded += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanded -= OnHealthChanged;
    }

    private void OnHealthChanged(int hertCount)
    {
        int createHealth = hertCount - _hearts.Count;
        int destroyHealth = _hearts.Count - hertCount;

        if (_hearts.Count < hertCount)
        {
            for (int i = 0; i < createHealth; i++)
            {
                CreateHert();
            }
        }
        else if(_hearts.Count > hertCount)
        {
            for (int i = 0; i < destroyHealth; i++)
            {
                DestroyHert(_hearts[_hearts.Count - 1]);
            }
        }
    }

    private void CreateHert()
    {
        Heart newHeart = Instantiate(_heartTemplate,transform);

        _hearts.Add(newHeart.GetComponent<Heart>());

        newHeart.ToFill();
    }

    private void DestroyHert(Heart heart)
    {
        _hearts.Remove(heart);
        heart.ToEmpty();
    }
}
