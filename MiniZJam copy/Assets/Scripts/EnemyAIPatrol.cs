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

    public Transform groundDetection;

    private void Start()
    {
        playerpos = new Vector3(player.transform.position.x,player.transform.position.y, player.transform.position.z);
    }

    private void Update()
    {
        FindTarget();
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D aiGroundDetect = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);

        if(aiGroundDetect.collider == false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            } else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

    private void FindTarget()
    {
        float TargetRange = targetrange;
        if(Vector3.Distance(transform.position, playerpos) < targetrange)
        {
            //player withing range

            Vector2.MoveTowards(transform.position, playerpos, attackRange);
        }

    
    }

}
