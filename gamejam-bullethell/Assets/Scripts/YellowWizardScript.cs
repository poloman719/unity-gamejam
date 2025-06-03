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

    public int beamCt;
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


        // Attacking
        if (timer > attackSpeed && !isAttacking)
        {
            
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
            int direction = UnityEngine.Random.Range(0,3);
            switch (direction)
            {
                case 0: // Left
                    Instantiate(beam, new Vector2(-5, UnityEngine.Random.Range(-4, (float)2.51)), Quaternion.Euler(new Vector3(0,0,90)));
                    break;
                case 1: // Right
                    Instantiate(beam, new Vector2(-8, UnityEngine.Random.Range(-4, (float)2.51)), Quaternion.Euler(new Vector3(0,0,-90)));
                    break;
                case 2: // Up
                    Instantiate(beam, new Vector2(UnityEngine.Random.Range((float) -8, (float) -4), 0), Quaternion.Euler(new Vector3(0,0,0)));
                    break;
                default:
                    Debug.Log("Error");
                    break;
            }
        }
    }
}
