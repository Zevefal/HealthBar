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

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _healthSlider = GetComponent<Slider>();

        _player.HealthChanged += SetHealth;
    }

    public void SetMaxHealth(int maximum)
    {
        _healthSlider.maxValue = maximum;
        _healthSlider.value = maximum;
    }

    private void SetHealth(int target)
    {
        StartCoroutine(AnimateSlider(target));
    }

    IEnumerator AnimateSlider(int target)
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
