using System;
using UnityEngine;

public class Attributes : MonoBehaviour
{
    [SerializeField] private int _level;
    [SerializeField] private int _str;
    [SerializeField] private int _end;
    [SerializeField] private int _agi;
    [SerializeField] private int _int;
    [SerializeField] private int _wil;

    [SerializeField] private string _name;

    public string Name => _name;
    public int Level => _level;
    public int Strength => _str;
    public int Endurance => _end;
    public int Agility => _agi;
    public int Intelligence => _int;
    public int Willpower => _wil;

    public Stats stats;
}

