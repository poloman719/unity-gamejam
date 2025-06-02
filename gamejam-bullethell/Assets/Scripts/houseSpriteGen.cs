using UnityEngine;

public class houseSpriteGen : MonoBehaviour
{
    public Sprite[] houseList;
    public SpriteRenderer sr;
    public Rigidbody2D rb;
    public float scrollRate;
    public GameObject itself;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr.sprite = houseList[Random.Range(0,5)];
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
