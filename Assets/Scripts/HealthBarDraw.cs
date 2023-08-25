using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBarDraw : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Player _player;

    private float _updateSpeed = 0.5f;

    private Coroutine _drawHealth;

    private void Awake()
    {
        _healthSlider = GetComponent<Slider>();

        _player.HealthChanged += SetMaxHealth;
    }

    private void OnEnable()
    {
        _player.HealthChanged += SetHealth;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= SetHealth;
    }

    private void SetMaxHealth(int maximum)
    {
        _healthSlider.maxValue = maximum;
        _healthSlider.value = maximum;

        _player.HealthChanged -= SetMaxHealth;
    }

    private void SetHealth(int target)
    {
        if (_drawHealth != null)
        {
            StopCoroutine(_drawHealth);
        }

        _drawHealth = StartCoroutine(AnimateSlider(target));
    }

    private IEnumerator AnimateSlider(int target)
    {
        float currentTime = 0f;

        while (currentTime < _updateSpeed)
        {
            currentTime += Time.deltaTime;
            _healthSlider.value = Mathf.MoveTowards(_healthSlider.value, target, currentTime / _updateSpeed);
            yield return null;
        }
    }
}
