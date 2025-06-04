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
        
        rb.linearVelocity = new Vector2((float)Math.Cos((transform.eulerAngles.z + 180) * Math.PI / 180), (float)Math.Sin((transform.eulerAngles.z + 180) * Math.PI / 180)) * 5;
         if (transform.position.y > 7 || transform.position.y < -7 || transform.position.x > 1 || transform.position.x < -14)
        {
            Destroy(gameObject);
        }
    }
}
