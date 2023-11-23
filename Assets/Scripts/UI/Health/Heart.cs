using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Heart : MonoBehaviour
{
    [SerializeField] private float _lerpDuration;

    private Image _hertIamg;

    private void Awake()
    {
        _hertIamg = GetComponent<Image>();
        _hertIamg.fillAmount = 1;
    }

    public void ToFill()
    {
        StartCoroutine(Filling(0, 1, _lerpDuration, Fill));
    }

    public void ToEmpty()
    {
        StartCoroutine(Filling(1, 0, _lerpDuration, Destroy));
    }

    private IEnumerator Filling(float startvalue, float endValue, float duration, UnityAction<float> lerpingEnd)
    {
        float elapsed = 0;
        float nextValue;

        while (elapsed < duration)
        {
            nextValue = Mathf.MoveTowards(startvalue, endValue, elapsed / duration);
            _hertIamg.fillAmount = nextValue;
            elapsed += Time.deltaTime;

            yield return null;
        }

        lerpingEnd?.Invoke(endValue);
    }

    private void Destroy(float value)
    {
        _hertIamg.fillAmount = value;
        Destroy(gameObject);
    }

    private void Fill(float value)
    {
        _hertIamg.fillAmount = value;
    }
}
