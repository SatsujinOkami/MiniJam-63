using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseScript : MonoBehaviour {
    public int maxHealth = 100;
    public GameObject player;   //here it goes the player
    private int currentHealth;

    // Start is called before the first frame update
    void Start() {
        currentHealth = maxHealth;
    }

    public void TakeDamage( int damage ) {
        currentHealth -= damage;

        if ( currentHealth <= 0 ) {
            Die();
        }
    }

    void Die() {
        Destroy(gameObject, 5);
        Debug.Log("Enemy ded");

        //Play death animation

    }


}
