using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Animator animator;

    public int maxHealth = 100;
    int currentHealth;
    Transform player;
    float agroRange;
    float moveSpeed;

    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {

        /*
        float distoplayer = Vector2.Distance(transform.position, player.position);

        if(distoplayer < agroRange)
        {
            chasePlayer();
        }
        else
        {
            stopChasingPlayer();
        }
        */
       
        currentHealth = currentHealth - damage;

        animator.SetTrigger("Hurt");


        if(currentHealth <= 0)
        {
            Die();
        }


    }

   /*  
    void chasePlayer()
    {
        if (transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-1, 1);

        }

    }

    void stopChasingPlayer()
    {
        rb2d.velocity = new Vector2(0, 0);
    }

    */
    void Die()
    {

        Debug.Log("Enemy Died!!");
        //enemy die animation
        animator.SetBool("IsDead", true);
        //disable enemy script

        GetComponent<Collider2D>().enabled = false;


        this.enabled = false;

    }



  
}
