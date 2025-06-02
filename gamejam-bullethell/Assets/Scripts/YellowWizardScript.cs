using UnityEngine;
using System;

public class YellowWizardScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject beam;
    public Animator animator;
    double timer = 0;
    public double attackSpeed = 5;

    public double attackTimer = 0;

    Boolean isAttacking = false;
    Boolean attackComplete = false;

    public int moveDirection = 0; // 0 -> not moving, -1 -> left, 1 -> right
    int prevMove = 0;

    double moveTimer = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
    }
    void moveWave()
    {
        rb.linearVelocity = new Vector2((float) (moveDirection), (float) (Math.Sin(moveTimer * 4) * 1.5));
    }
}
