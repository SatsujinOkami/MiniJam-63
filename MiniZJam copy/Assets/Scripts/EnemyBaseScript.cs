using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseScript : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //plays hurt animation
        

        //kills if loses all health
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Attack();
        }
    }


    void Attack()
    {
        //Damage Player


        //Player Knockback

        //Attack animation
    }

    void Die()
    {
        Debug.Log("Enemy ded");

        //Play death animation

        //disable script
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

    
}
