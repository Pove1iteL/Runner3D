using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private Light _light;
    private float _maxIntensity = 60;
    private int _procentCount = 10;

    public event UnityAction Died;
    public event UnityAction<int> HealthChanded;

    private void Start()
    {
        _light = GetComponentInChildren<Light>();
        _light.intensity = _maxIntensity;
        HealthChanded?.Invoke((int)(_light.intensity / _procentCount));
    }

    public void AddIntensity(float intensity)
    {
        _light.intensity += intensity;

        if (_light.intensity >= _maxIntensity)
            _light.intensity = _maxIntensity;

        HealthChanded?.Invoke((int)(_light.intensity / _procentCount));

    }

    public void GiveIntensity(float intensity)
    {
        _light.intensity -= intensity;
        HealthChanded?.Invoke((int)(_light.intensity / _procentCount));

        if (_light.intensity <= 0)
            Die();
    }

    public void Die()
    {
        Died?.Invoke();
        Time.timeScale = 0;
    }
}
