using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    public float standTime;
    public float destroyTime;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            PlatformManager.instance.StartCoroutine("SpawnPlatform",
                new Vector2(transform.position.x, transform.position.y));
            Invoke("DropPlatform", standTime);
            Destroy(gameObject, destroyTime);
        }
    }

    void DropPlatform()
    {
        rb.isKinematic = false;
    }
}
