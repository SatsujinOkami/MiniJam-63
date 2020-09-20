using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;

    public int playerHealth = 100;


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") || playerHealth == 0f)
        {
            collision.transform.position = spawnPoint.position;
        }
    }

   
        
    

    
}
