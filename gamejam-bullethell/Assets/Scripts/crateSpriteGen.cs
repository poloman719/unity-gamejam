using UnityEngine;

public class crateSpriteGen : MonoBehaviour
{
    public Rigidbody2D rb;
    public float scrollRate;
    public GameObject itself;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(0, -1 * scrollRate);
        if (rb.position.y < -10)
        {
            Destroy(itself);
        }
    }
}
