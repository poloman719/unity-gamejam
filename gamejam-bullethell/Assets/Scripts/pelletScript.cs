using Unity.VisualScripting;
using UnityEngine;

public class pelletScript : MonoBehaviour
{
    double timer;
    public float rotationSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1) * rotationSpeed * Time.deltaTime);
        if (transform.position.y > 7 || transform.position.y < -7 || transform.position.x > 1 || transform.position.x < -14)
        {
            Destroy(gameObject);
        }
    }
}
