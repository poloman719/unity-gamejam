using UnityEngine;

public class crateSpriteGen : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public GameObject HealthBar;
    public float scrollRate;
    public GameObject itself;
    public Sprite brokenCrate;
    public Collider2D boxCollider;
    public AudioSource destroyedSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HealthBar.GetComponent<HealthBar>().onDeath = OnDeath;
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "PlayerProjectile(Clone)")
        {
            Debug.Log(gameObject.name + " damaged");
            HealthBar.GetComponent<HealthBar>().changeHealth(-10);
            // takingDamage = true;
        }
    }

    public void OnDeath()
    {
        Debug.Log("I died");
        sr.sprite = brokenCrate;
        boxCollider.enabled = false;
        destroyedSound.Play();
    }
}
