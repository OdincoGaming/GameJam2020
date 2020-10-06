using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BuffType {DamageResist, Damage, Speed, Confusion, Accuracy}

public class Buff : MonoBehaviour
{
    [SerializeField] private BuffType _type;
    [SerializeField] private int _turnsLeft;
    [SerializeField] private int _value;

    public BuffType buffType => _type;
    public int turnsLeft => _turnsLeft;
    public int value => _value;
}
