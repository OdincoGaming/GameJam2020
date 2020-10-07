using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AttackAction : SAction
{
    [SerializeField] private int _dmg;
    [SerializeField] private AnimationClip userAnim;

    public int Damage => _dmg;
    public AnimationClip UserAnimation => userAnim;
}
