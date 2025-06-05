using UnityEngine;
using System;

public class drillScript : MonoBehaviour
{
    double timer = 0;
    public double releaseTimer = 1;
    public GameObject debris;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > releaseTimer)
        {
            debrisRelease();
            timer = 0;
        }
        if (transform.position.y > 7 || transform.position.y < -7 || transform.position.x > 1 || transform.position.x < -14)
        {
            Destroy(gameObject);
        }
        gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2((float)Math.Cos((transform.eulerAngles.z + 270) * Math.PI / 180), (float)Math.Sin((transform.eulerAngles.z + 270) * Math.PI / 180)) * 5;
    }

    [ContextMenu("Release Debris")]
    public void debrisRelease()
    {
        GameObject debris1 = Instantiate(debris, transform.position, Quaternion.Euler(new Vector3(0, 0, transform.eulerAngles.z)));
        GameObject debris2 = Instantiate(debris, transform.position, Quaternion.Euler(new Vector3(0, 0, 180 + transform.eulerAngles.z)));
    }
}
