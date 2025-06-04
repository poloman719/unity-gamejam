using System;
using UnityEngine;

public class debrisScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public double bulletSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotation = transform.rotation.z;
        rb.linearVelocity = new Vector2((float) (Math.Cos(rotation * Math.PI / 180)), (float) (Math.Sin(rotation * Math.PI / 180)))  * (float) bulletSpeed;
         if (transform.position.y > 7 || transform.position.y < -7 || transform.position.x > 1 || transform.position.x < -14)
        {
            Destroy(gameObject);
        }
    }
}
