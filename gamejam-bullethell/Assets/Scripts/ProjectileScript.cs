using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D rb;
    public GameObject wizardObject;

    void Start()
    {
        wizardObject = GameObject.FindWithTag("Wizard");
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.position.y < -13) Destroy(gameObject);
    }
}
