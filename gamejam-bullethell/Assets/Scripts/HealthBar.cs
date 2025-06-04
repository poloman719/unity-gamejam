using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Sprite[] healthBarSprites;
    public SpriteRenderer spriteRenderer;
    public float maxHealth = 100;
    public float currentHealth;
    public delegate void OnDeath();
    public OnDeath onDeath;
    public AudioSource hitSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        renderHealth();
    }

    // changes currentHealth by a given amount
    public void changeHealth(float amount)
    {
        currentHealth += amount;
        hitSound.Play();
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        if (currentHealth < 0)
        {
            currentHealth = 0;
            Debug.Log(gameObject + " DIED");
            GameObject parent = transform.parent.gameObject;
            onDeath();
            // if (parent.GetComponent<RedWizardScript>().OnDeath)
            // {
            // parent.GetComponent<RedWizardScript>().OnDeath();
            // calls OnDeath function on parent object
            // }
        }
        renderHealth();
        Debug.Log(gameObject + ": Health decreased by " + amount + ", Current Health: " + currentHealth);
    }

    // updates the sprite renderer to display the current health
    void renderHealth()
    {
        int index = Mathf.CeilToInt(currentHealth / maxHealth * (healthBarSprites.Length - 1));
        spriteRenderer.sprite = healthBarSprites[index];
    }

    // Update is called once per frame
    void Update()
    {
    }
}
