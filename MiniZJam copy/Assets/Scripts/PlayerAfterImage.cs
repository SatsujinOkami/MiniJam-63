using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //how long its been active
    [SerializeField]
    private float activeTime = 0.1f;
    private float timeActivated;

    //tracks current alpha
    private float alpha;

    //sets alpha at beginning
    private float alphaSet = 0.8f;

    //decreases alphga over time. Smaller number = faster fade
    [SerializeField]
    private float alphaMultiplier = 0.85f;

    private Transform player;

    private SpriteRenderer SR;
    private SpriteRenderer playerSR;

    private Color color;


    private void OnEnable()
    {
        SR = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerSR = player.GetComponent<SpriteRenderer>();

        alpha = alphaSet;
        SR.sprite = playerSR.sprite;
        transform.position = player.position;
        transform.rotation = player.rotation;
        timeActivated = Time.time;
    }
    private void Update()
    {
        alpha *= alphaMultiplier;
        color = new Color(1f, 1f, 1f, alpha);
        SR.color = color;

        if(Time.time >= (timeActivated + activeTime))
        {
            //add images back to pool
            PlayerAfterImagePool.Instance.AddToPool(gameObject);
        }

    }



}
