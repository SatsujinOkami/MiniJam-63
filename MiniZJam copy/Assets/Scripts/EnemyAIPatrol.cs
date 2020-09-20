using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIPatrol : MonoBehaviour
{
    public GameObject player;
    public float targetrange;
    public float speed;
    public float attackRange;
    private bool movingRight = true;
    Vector2 playerpos;
    public Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed;
    public bool inRange = false;
    

    public Transform groundDetection;

    private void Start()
    {
        rb .GetComponent<Rigidbody2D>();
        playerpos = new Vector3(player.transform.position.x,player.transform.position.y, player.transform.position.z);
    }

    private void Update()
    {
        FindTarget();

        if (inRange == false)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            RaycastHit2D aiGroundDetect = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);

            if (aiGroundDetect.collider == false)
            {
                if (movingRight == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = true;
                }


            }
        }
        
        
    }

    void fixedUpdate()
    {
        if (inRange == true)
        {
            moveEnemy(movement);

        }
    }


    void moveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }



    private void FindTarget()
    {
        float TargetRange = targetrange;
        if (Vector3.Distance(transform.position, playerpos) < targetrange)
        {
            //player withing range
            inRange = true;
            Vector2 direction = player.transform.position - transform.position;
            Debug.Log(direction);

            direction.Normalize();
            movement = direction;


        }
        else inRange = false;

        

        



    
    }

}
