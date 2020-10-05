using System;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] private int _currentHealth;
    [SerializeField] private int _maxHealth;

    [SerializeField] private int _dmgResist;

    public List<GameObject> buffs = new List<GameObject>();
    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;

    public void InitializeEnemy()
    {
        _currentHealth = _maxHealth;
    }
    public void InitializePlayer()
    {
        //do something
    }

    public void receiveAttack(Attack attack)
    {
        _currentHealth -= attack.Damage;
    }
    public void useAttack(Attack attack)
    {
        //do something
    }

}
