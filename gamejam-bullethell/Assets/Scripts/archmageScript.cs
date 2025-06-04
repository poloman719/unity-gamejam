using System.Threading;
using UnityEngine;
using System;

public class archmageScript : MonoBehaviour
{
    // Game Objects
    public Animator archmageAnimator;
    public GameObject beam;
    public GameObject ball;
    public GameObject drill;
    public GameObject archmageBallPellet;
    public GameObject playerWagon;
    public Rigidbody2D rb;

    // Attack Variables
    public int staticBeamCt;
    public int movingBeamCt;

    // Timers
    public double timer;
    public double moveTimer;
    public double attackTimer;

    //Movement
    public int moveDirection = -1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        moveTimer += Time.deltaTime / 2;
        moveWave();
    }

    [ContextMenu("Static Beam Attack")]
    public void stillBeamAttack()
    {
        for (int i = 0; i < staticBeamCt; i++)
        {
            int direction = UnityEngine.Random.Range(0, 3);
            switch (direction)
            {
                case 0: // Left
                    Instantiate(beam, new Vector2(-3, UnityEngine.Random.Range(-4, (float)2.51)), Quaternion.Euler(new Vector3(0, 0, 90)));
                    break;
                case 1: // Right
                    Instantiate(beam, new Vector2(-10, UnityEngine.Random.Range(-4, (float)2.51)), Quaternion.Euler(new Vector3(0, 0, -90)));
                    break;
                case 2: // Up
                    Instantiate(beam, new Vector2(UnityEngine.Random.Range((float)-10, (float)-4), (float)-2.75), Quaternion.Euler(new Vector3(0, 0, 0)));
                    break;
                default:
                    Debug.Log("Error");
                    break;
            }
        }
    }

    [ContextMenu("Beam Sweep Attack")]
    public void beamSweepAttack()
    {

    }

    [ContextMenu("Ball Attack")]
    public void ballinAttack()
    {
        float playerX = playerWagon.transform.position.x;
        float playerY = playerWagon.transform.position.y;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, (float)Math.Atan((transform.position.y - playerY) / (transform.position.x - playerX))));
        GameObject ballin = Instantiate(ball, transform.position, transform.rotation);
        ballin.GetComponent<Rigidbody2D>().linearVelocity = new Vector2((float)Math.Cos((rotation.eulerAngles.z) * Math.PI / 180), (float)Math.Sin((rotation.eulerAngles.z) * Math.PI / 180)) * 2;
    }

    [ContextMenu("Screw Attack")]
    public void screwAttack()
    {
        float playerX = playerWagon.transform.position.x;
        float playerY = playerWagon.transform.position.y;
    }

    [ContextMenu("Death Explosion")]
    public void deathExplosion()
    {

    }
    
    void moveWave()
    {
        if (rb.position.x > -4.5)
        {
            moveDirection = -1;
        }
        if (rb.position.x < -8.7)
        {
            moveDirection = 1;
        }
        rb.linearVelocity = new Vector2((float)(moveDirection), (float)(Math.Sin(moveTimer * 4)));
    }
}
