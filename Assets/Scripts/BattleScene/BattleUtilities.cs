using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class BattleUtilities : MonoBehaviour
{
    [SerializeField] private BattleController battle;
    public void UseAttack(Attack attack, Character user, Character target)
    {
        user.UpdateAnimator(attack.UserAnimation);

        target.stats.receiveAttack(attack);
        user.stats.useAttack(attack);
    }

    public  string SelectEnemyMove(Character enemy, Character player, BattleState state)
    {
        string actionTaken = "attack";  
        return actionTaken;
    }
}
