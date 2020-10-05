using System;
using UnityEngine;

[CreateAssetMenu]
public class Attack : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _dmg;
    [SerializeField] private AnimationClip userAnim;

    public string Name => _name;
    public int Damage => _dmg;
    public AnimationClip UserAnimation => userAnim;
}
