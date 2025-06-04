using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class archmageBallin : MonoBehaviour
{
    public GameObject pellet;
    double timer;
    public double releaseTimer;
    public float rotationSpeed;
    float currentRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, 1) * rotationSpeed * Time.deltaTime);
        currentRotation = transform.rotation.z;
        if (releaseTimer < timer)
        {
            sprayBullet();
            timer = 0;
        }
        if (transform.position.y > 7 || transform.position.y < -7 || transform.position.x > 1 || transform.position.x < -14)
        {
            Destroy(gameObject);
        }
    }


    public void sprayBullet()
    {
        for (int i = 0; i < 8; i++)
        {
            GameObject bullet = Instantiate(pellet, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().linearVelocity = new Vector2((float) Math.Sin((i * 45) * Math.PI / 180 + currentRotation), (float) Math.Cos((i * 45) * Math.PI / 180 + currentRotation));
        }
    }
}
