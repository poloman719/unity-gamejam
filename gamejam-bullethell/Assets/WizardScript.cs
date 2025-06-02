using UnityEngine;
using System;

public class WizardScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D rb;
    public GameObject projectileObject;
    double timer = 0;

    public float bulletSpeed;

    public int moveDirection = 0; // 0 -> not moving, -1 -> left, 1 -> right
    double moveTimer = 0;

    // public Vector2 projectileVelocity = Vector2.zero;

    void Start()
    {
        projectileObject = GameObject.FindWithTag("Projectile");
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        moveTimer += Time.deltaTime;
        moveWave();
        if (timer > 1)
        {
            timer = 0;
            double angleDelta = 20;
            shootProjectile(270);
            shootProjectile(270 + angleDelta);
            shootProjectile(270 + -angleDelta);
            shootProjectile(270 + 2 * angleDelta);
            shootProjectile(270 + -2 * angleDelta);
            shootProjectile(270 + 3 * angleDelta);
            shootProjectile(270 + -3 * angleDelta);
        }
        
    }

    void shootProjectile(double angle)
    {
        int prevMove = moveDirection;
        moveDirection = 0;
        GameObject newObject = GameObject.Instantiate(projectileObject, rb.position, Quaternion.identity);
        newObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2((float)Math.Cos(angle * Math.PI / 180), (float)Math.Sin(angle * Math.PI / 180)) * bulletSpeed;
        newObject.transform.Rotate(new Vector3(0, 0, (float)angle + 90));
        moveDirection = prevMove;
    }

    [ContextMenu("Attack 1 - Spray")]
    public void sprayAttack()
    {
        double angleDelta = 20;
        shootProjectile(270);
        shootProjectile(270 + angleDelta);
        shootProjectile(270 + -angleDelta);
        shootProjectile(270 + 2 * angleDelta);
        shootProjectile(270 + -2 * angleDelta);
        shootProjectile(270 + 3 * angleDelta);
        shootProjectile(270 + -3 * angleDelta);
    }

    void moveWave()
    {
        rb.linearVelocity = new Vector2((float) (moveDirection), (float) (Math.Sin(moveTimer) * 0.25));
    }
}
