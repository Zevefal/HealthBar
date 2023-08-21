using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] public HealthBarDraw _healthDraw;

    [SerializeField] private int _maxHP = 100;
    [SerializeField] private int _currentHP;

    public event Action<int> HealthChanged;

    private void Start()
    {
        _currentHP = _maxHP;
        _healthDraw.SetMaxHealth(_maxHP);
    }

    public void TakeDamage(int damage)
    {
        _currentHP -= damage;
        
        if(_currentHP <= 0)
        {
            _currentHP = 0;
        }

        HealthChanged?.Invoke(_currentHP);
    }

    public void Healing(int heal)
    {
        _currentHP += heal;

        if (_currentHP >= _maxHP)
        {
            _currentHP = _maxHP;
        }

        HealthChanged?.Invoke(_currentHP);
    }
}
