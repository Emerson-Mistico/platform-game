using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    #region Setup
    [Header("Enemy Setup")]
    public int damage;

    [Header("Enemy Animation Setup")]
    public string triggerAttack = "Attack";
    public float attackAnimationSpeed = 2.1f;
    public Animator animator;

    [Header("Audio Enemie Setup")]
    public AudioSource sndTakeDamage;

    #endregion

    public HelthBase thisHealthBase;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var health = collision.gameObject.GetComponent<HelthBase>();

        if (health != null & thisHealthBase.currentLife > 0)
        {
            health.Damage(damage);
            ExecuteAttack();
        }
    }

    private void ExecuteAttack()
    {
        // Enter Rage Mode
        // Future implement: IA to back iddle in normal velocity if player is far away
        animator.speed = attackAnimationSpeed;
        animator.SetBool(triggerAttack, true);
    }

    public void TakeDamage(int amount)
    {
        thisHealthBase.Damage(amount);
        if(sndTakeDamage != null)
        {
            sndTakeDamage.Play();
        }
    }

}
