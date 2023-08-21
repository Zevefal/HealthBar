using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    [SerializeField] private Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }
    public void Heal()
    {
        _player.Healing(10);
    } 

    public void Damage()
    {
        _player.TakeDamage(10);
    }
}
