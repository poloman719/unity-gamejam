using UnityEngine;
using System;

public class WizardScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D rb;
    public GameObject projectileObject;
    public Animator animator;
    double timer = 0;
    public double attackSpeed = 5;

    public double attackTimer = 0;

    Boolean isAttacking = false;
    Boolean attackComplete = false;
    public float bulletSpeed;

    public int moveDirection = 0; // 0 -> not moving, -1 -> left, 1 -> right
    int prevMove = 0;

    double moveTimer = 0;

    // public Vector2 projectileVelocity = Vector2.zero;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Increment Timers
        timer += Time.deltaTime;
        moveTimer += Time.deltaTime * 0.5;

        moveWave();

        // Attack Timer
        if (timer > attackSpeed && !isAttacking)
        {
            isAttacking = true;
            prevMove = moveDirection;
            moveDirection = 0;
            animator.SetBool("Attacking", true);
        }

        if (isAttacking)
        {
            attackTimer += Time.deltaTime;
        }
        else
        {
            // Set movement direction
            if (rb.position.x > -3)
            {
                moveDirection = -1;
            }
            if (rb.position.x < -7)
            {
                moveDirection = 1;
            }
        }

        if (attackTimer > 1.5 && !attackComplete)
        {
            sprayAttack();
            moveDirection = prevMove;
            attackComplete = true;
        }

        if (attackTimer > 2.5)
        {
            timer = 0;
            attackTimer = 0;
            isAttacking = false;
            attackComplete = false;
            animator.SetBool("Attacking", false);
        }
    }

    void shootProjectile(double angle)
    {
        GameObject newObject = GameObject.Instantiate(projectileObject, rb.position, Quaternion.identity);
        newObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2((float)Math.Cos(angle * Math.PI / 180), (float)Math.Sin(angle * Math.PI / 180)) * bulletSpeed;
        newObject.transform.Rotate(new Vector3(0, 0, (float)angle + 90));
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
        rb.linearVelocity = new Vector2((float) (moveDirection), (float) (Math.Sin(moveTimer * 4) * 1.5));
    }
}
