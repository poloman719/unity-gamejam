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

    // Movement
    public int moveDirection = -1;
    public int prevMove;
    public double teleportCooldown = 0;

    // Attack Speed
    public double attackSpeed;
    bool attacked = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        moveTimer += Time.deltaTime / 3;
        moveWaveModified();

        if (timer > attackSpeed && !attacked)
        {
            prevMove = moveDirection;
            moveDirection = 0;
            attacked = true;
            archmageAnimator.SetTrigger("Attacking");
            switch (UnityEngine.Random.Range(1, 5))
            {

                case 1:
                    stillBeamAttack();
                    break;
                case 2:
                    beamSweepAttack();
                    break;
                case 3:
                    ballinAttack();
                    break;
                case 4:
                    screwAttack();
                    break;
                default:
                    Debug.Log("Archmage Move Select Error");
                    break;
            }
        }
        if (timer > attackSpeed + 2.5)
        {
            timer = 0;
            moveDirection = prevMove;
            attacked = false;
            archmageAnimator.ResetTrigger("Attacking");
        }
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
                    Instantiate(beam, new Vector2(-10, UnityEngine.Random.Range((float) -3.75, (float)3)), Quaternion.Euler(new Vector3(0, 0, 90)));
                    break;
                case 1: // Right
                    Instantiate(beam, new Vector2(-3, UnityEngine.Random.Range((float) -3.75, (float)3)), Quaternion.Euler(new Vector3(0, 0, -90)));
                    break;
                case 2: // Up
                    Instantiate(beam, new Vector2(UnityEngine.Random.Range((float)-10, (float)-4), (float) 3.75), Quaternion.Euler(new Vector3(0, 0, 0)));
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
        for (int i = 0; i < movingBeamCt; i++)
        {
            int direction = UnityEngine.Random.Range(0, 2);
            switch (direction)
            {
                case 0: // Left
                    Instantiate(beam, new Vector2(-10, UnityEngine.Random.Range((float)-3.75, (float)3)), Quaternion.Euler(new Vector3(0, 0, 90)));
                    break;
                case 1: // Right
                    Instantiate(beam, new Vector2(-3, UnityEngine.Random.Range((float)-3.75, (float)3)), Quaternion.Euler(new Vector3(0, 0, -90)));
                    break;
                default:
                    Debug.Log("Error");
                    break;
            }
        }
        GameObject movingBeam = Instantiate(beam, new Vector2(-10, (float)3.75), transform.rotation);
        movingBeam.AddComponent<MovingBeamScript>();
    }

    [ContextMenu("Ball Attack")]
    public void ballinAttack()
    {
        GameObject ballin = Instantiate(ball, transform.position, transform.rotation);
        ballin.transform.right = playerWagon.transform.position - transform.position;
        ballin.GetComponent<Rigidbody2D>().linearVelocity = new Vector2((float)Math.Cos((ballin.transform.eulerAngles.z + 180) * Math.PI / 180), (float)Math.Sin((ballin.transform.eulerAngles.z + 180) * Math.PI / 180)) * -2;
    }

    [ContextMenu("Screw Attack")]
    public void screwAttack()
    {
        GameObject drillAttack = Instantiate(drill, transform.position, transform.rotation);
        drillAttack.transform.up = (playerWagon.transform.position - transform.position) * -1;
    }

    [ContextMenu("Death Explosion")]
    public void deathExplosion()
    {
        for (int i = 0; i < 32; i++)
        {
            GameObject bullet = Instantiate(archmageBallPellet, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().linearVelocity = new Vector2((float)Math.Sin((i * 11.25) * Math.PI / 180 + transform.rotation.z), (float)Math.Cos((i * 11.25) * Math.PI / 180 + transform.rotation.z));
        }
    }

    void moveWaveModified()
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
        int teleportChance = UnityEngine.Random.Range(0, 100);
        if (teleportChance == 0 && teleportCooldown <= 0)
        {
            archmageAnimator.ResetTrigger("Teleporting");
            gameObject.transform.position = new Vector2((float)(-3.33 * UnityEngine.Random.Range(1, 4)), transform.position.y);
            archmageAnimator.SetTrigger("Teleporting");
            teleportCooldown = 5;
        }
        if (teleportCooldown > 0)
        {
            teleportCooldown -= Time.fixedDeltaTime;
        }
    }
}
