using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator anim;
    [SerializeField] private Collider2D SlideDisableCollider;				// A collider that will be disabled when crouching

    public GameObject player;

    float horizontalMove = 0f;
    public float runSpeed = 50f;
    bool jump = false;
    bool crouch = false;
    bool canMove = true;

    //dash variables

    //tracks if player is dashing
    public bool isDashing = false;
    //how long dash should take
    public float dashTime;
    //how fast player moves in dash
    public float dashSpeed;
    //how far after image is placed
    public float distanceBetweenImages;
    //time before next dash is allowed
    public float dashcooldown;
    //tracks how much longer dash is happening
    private float dashTimeLeft;
    //tracks last xpos of after image
    private float lastImageXpos;
    //tracks last time dash was started
    private float lastDash = -100f;

    //Slide variables

    //tracks if player is dashing
    public bool isSliding = false;
    //how long dash should take
    public float slideTime;
    //how fast player moves in dash
    public float slideSpeed;
    //time before next dash is allowed
    public float slidecooldown;
    //tracks how much longer dash is happening
    private float slideTimeLeft;
    //tracks last xpos of after image
    //tracks last time dash was started
    private float lastSlide = -100f;

    public enum AnimState
    {
        idle,
        run,

    }

    private AnimState animstate = AnimState.idle;

    // Update is called once per frame
    void Update()
    {
        CheckDash();
        CheckSlide();

        if (canMove == true)
        {
            if (isDashing == false && isSliding == false)
            {
                //records horizontal axis value & applies player's run speed
                horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
                if (controller.m_Grounded == true && horizontalMove != 0)
                {
                    anim.SetInteger("AnimState", 1);

                }
                else anim.SetInteger("AnimState", 0);

            }



            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                anim.SetTrigger("Jump");
            }


            //Crouch button down causes player to crouch
            if (Input.GetButtonDown("Crouch"))
            {
                crouch = true;
            }
            //Ends crouch on button up
            else if (Input.GetButtonUp("Crouch"))
            {
                crouch = false;

            }
        }

        if (Input.GetButtonDown("Dash"))
        {
            if (Time.time >= (lastDash + dashcooldown))
            {
                AttemptToDash();
                anim.SetTrigger("Dash");


            }

        }

        if (Input.GetButtonDown("Slide"))
        {
            if (Time.time >= (lastSlide + slidecooldown))
            {
                GetComponent<BoxCollider2D>().enabled = false;

                AttemptToSlide();
                anim.SetTrigger("Slide");



            }else if(slideTimeLeft <= 0f)
            {
                GetComponent<BoxCollider2D>().enabled = true;

            }



        }
    }


    //Move Character
    void FixedUpdate()
    {
        //Allows character to move and adjusts speed for frame rate differences
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);

        //releases jump after jump is called
        jump = false;


    }


    private void AttemptToDash()
    {
        isDashing = true;
        dashTimeLeft = dashTime;
        lastDash = Time.time;

        PlayerAfterImagePool.Instance.GetFromPool();
        lastImageXpos = transform.position.x;
    }

    private void AttemptToSlide()
    {
        isSliding = true;
        slideTimeLeft = slideTime;
        lastSlide = Time.time;

        PlayerAfterImagePool.Instance.GetFromPool();
        lastImageXpos = transform.position.x;
    }


    private void CheckDash()
    {
        if (isDashing == true)
        {
            if (dashTimeLeft > 0)
            {
                controller.canFlip = false;
                canMove = false;
                horizontalMove = Input.GetAxisRaw("Horizontal") * dashSpeed;
                dashTimeLeft -= Time.deltaTime;

                if (Mathf.Abs(transform.position.x - lastImageXpos) > distanceBetweenImages)
                {
                    PlayerAfterImagePool.Instance.GetFromPool();
                    lastImageXpos = transform.position.x;
                }

            }
            else
            {
                canMove = true;
                controller.canFlip = false;
            }

            if (dashTimeLeft <= 0)
            {
                isDashing = false;
                canMove = true;
                controller.canFlip = true;
            }
        }


    }

    private void CheckSlide()
    {
        if (isSliding == true)
        {
            if (slideTimeLeft > 0)
            {
                controller.canFlip = false;
                canMove = false;
                horizontalMove = Input.GetAxisRaw("Horizontal") * slideSpeed;
                slideTimeLeft -= Time.deltaTime;


            }
            else
            {
                canMove = true;
                controller.canFlip = false;
            }

            if (slideTimeLeft <= 0)
            {
                isSliding = false;
                canMove = true;
                controller.canFlip = true;
            }

            // Disable one of the colliders when crouching

            if (SlideDisableCollider != null)
            {
                SlideDisableCollider.enabled = false;
            }

        }
        else
        {
            // Enable the collider when not crouching
            if (SlideDisableCollider != null)
                SlideDisableCollider.enabled = true;
        }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Platform"))
        {
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    { 
    
        if (collision.collider.CompareTag("Platform"))
        {
            collision.collider.transform.SetParent(null);
        }
    }


}


