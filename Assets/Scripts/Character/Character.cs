using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Character : MonoBehaviour
{
    public Attributes attr;
    public Stats stats;
    public AttackAction attack;
    public Animator animator;
    public AnimatorOverrideController animOverride;
    public AnimationClip Idle;

    private void Start()
    {
        animator.runtimeAnimatorController = animOverride;
        UpdateAnimator(Idle);
    }

    public void UpdateAnimator(AnimationClip clip)
    {
        AnimatorStateInfo[] layerInfo = new AnimatorStateInfo[animator.layerCount];
        for (int i = 0; i < animator.layerCount; i++)
        {
            layerInfo[i] = animator.GetCurrentAnimatorStateInfo(i);
        }

        // Do swap clip in override controller here
        animOverride["Idle"] = clip;

        // Push back state
        for (int i = 0; i < animator.layerCount; i++)
        {
            animator.Play(layerInfo[i].fullPathHash, i, layerInfo[i].normalizedTime);
        }

        // Force an update
        animator.Update(0.0f);
    }
}
