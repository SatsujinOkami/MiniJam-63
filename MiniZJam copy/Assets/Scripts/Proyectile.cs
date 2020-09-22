using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * speed);
    }
    public void OnCollisionEnter2D( Collision2D collision ) {
        Debug.Log("kpow");
        Destroy(this.gameObject, 2);

    }
}
