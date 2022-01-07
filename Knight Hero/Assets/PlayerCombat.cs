using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator_attack;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 20;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    // Update is called once per frame
    void Update()
    {

        if(Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;

            }
        }
        //1, attack animation.
        //2. attack button code
        /*else if (Input.GetButtonUp("Fire1"))
        {
            nAttack();
        }
        */
    }

    void Attack()
    {
        animator_attack.SetTrigger("Attack");

       Collider2D [] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    void nAttack()
    {
        animator_attack.SetTrigger("nAttack");
    }
  
    void OnDrawGizmos()
    {
       
       
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
   
   
}


