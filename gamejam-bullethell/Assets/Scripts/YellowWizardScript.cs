using UnityEngine;
using System;

public class YellowWizardScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject beam;
    public GameObject HealthBar;
    public Animator animator;
    public double timer = -2;
    public double attackSpeed;

    public double attackTimer = 0;
    public double deathTime = 1;
    public double deathTimer = 0;
    public bool dying = false;
    public int moveDirection = 0; // 0 -> not moving, -1 -> left, 1 -> right
    public delegate void RemoveSelf();
    public RemoveSelf removeSelf;
    public AudioSource deathSound;


    bool isAttacking = false;
    bool attackComplete = false;

    int prevMove = 0;

    double moveTimer = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int beamCt;
    void Start()
    {
        beamCt = UnityEngine.Random.Range(2, 4);
        HealthBar.GetComponent<HealthBar>().onDeath = OnDeath;
    }

    // Update is called once per frame
    void Update()
    {
        if (dying)
        {
            Debug.Log("dying: " + deathTimer);
            deathTimer += Time.deltaTime;
            if (deathTimer > deathTime)
            {
                Debug.Log("i like actually died");
                removeSelf();
                Destroy(gameObject);
                deathSound.Play();

            }
            return;
        }

        // Set movement direction
        if (rb.position.x > -3.75)
        {
            moveDirection = -1;
        }
        if (rb.position.x < -9.5)
        {
            moveDirection = 1;
        }
        timer += Time.deltaTime;
        moveTimer += Time.deltaTime;
        moveWave();


        // Attacking
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

        if (attackTimer > 0.25 && !attackComplete)
        {
            beamAttack();
            attackComplete = true;
        }

        if (attackTimer > 3.417)
        {
            animator.SetBool("Attacking", false);
            moveDirection = prevMove;
            isAttacking = false;
            attackComplete = false;
            attackTimer = 0;
            timer = 0;
        }
    }
    void moveWave()
    {
        rb.linearVelocity = new Vector2((float)(moveDirection), (float)(Math.Sin(moveTimer * 4) * 1.5));
    }

    [ContextMenu("Beam Attack")]
    public void beamAttack()
    {
        for (int i = 0; i < beamCt; i++)
        {
            int direction = UnityEngine.Random.Range(0, 3);
            switch (direction)
            {
                case 0: // Left
                    Instantiate(beam, new Vector2(-5, UnityEngine.Random.Range(-4, (float)2.51)), Quaternion.Euler(new Vector3(0, 0, 90)));
                    break;
                case 1: // Right
                    Instantiate(beam, new Vector2(-8, UnityEngine.Random.Range(-4, (float)2.51)), Quaternion.Euler(new Vector3(0, 0, -90)));
                    break;
                case 2: // Up
                    Instantiate(beam, new Vector2(UnityEngine.Random.Range((float)-8, (float)-4), 0), Quaternion.Euler(new Vector3(0, 0, 0)));
                    break;
                default:
                    Debug.Log("Error");
                    break;
            }
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
        animator.SetTrigger("Dead");
        dying = true;
    }
}
