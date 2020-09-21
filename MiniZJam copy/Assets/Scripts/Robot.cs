using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : EnemyBaseScript
{
    public float targetRange;
    public float moveSpeed;
    public float fireCooldown;
    public GameObject proyectile;
    bool isDetected;
    bool isFlipped;
    Vector2 endposition;
    Rigidbody2D rb;
    float fireTimer;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        endposition = transform.position + transform.right * targetRange;
    }
    // Update is called once per frame
    void Update()
    {
        Patrol();
    }
    private void FixedUpdate() {
        if ( isDetected == false ) {
            //Movement and sprite rotation. First check the position, then move
            if ( Vector2.Distance(transform.position, endposition) < 0.5f ) {
                isFlipped = true;
                transform.eulerAngles = new Vector3(0, -180, 0);
            } else if ( Vector2.Distance(transform.position, endposition) > targetRange ) {
                isFlipped = false;
                transform.eulerAngles = new Vector3(0, 0, 0);

            }
            Movement(transform.right);
        } else {
            fireTimer += Time.deltaTime;
            if ( fireTimer > fireCooldown ) {
                Vector2 pewDir;
                if ( isFlipped ) {
                    pewDir = -transform.right;
                }else {
                    pewDir = transform.right;
                }
                Instantiate(proyectile, pewDir, Quaternion.identity);
                fireTimer = 0;
            }
        }


    }
    public void Patrol() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + transform.right * 0.5f, transform.right, targetRange);
        if(hit.collider.gameObject == player ) {
            isDetected = true;
        } else {
            isDetected = false;
        }
    }
    void Movement( Vector2 direction ) {
        rb.MovePosition((Vector2) transform.position + (direction * moveSpeed * Time.deltaTime));
    }
    private void OnDrawGizmos() {
        //Gizmos.DrawLine(transform.position, transform.position + transform.right * targetRange);
        Gizmos.DrawSphere(endposition, 0.1f);
    }

}
;