using UnityEngine;

public class MovingBeamScript : MonoBehaviour
{
    double timer = 0;
    public double fireTime = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.right * (float)1.9;
        }

        if (timer > fireTime)
        {
            GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, 0);
        }
    }
}
