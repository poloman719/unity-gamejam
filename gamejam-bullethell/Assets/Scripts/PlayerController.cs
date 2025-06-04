using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public int speed = 20;
    public float dashFactor = 5F;
    public float friction = 0.01F;

    public float xLowerBound = -10f;
    public float xUpperBound = 0f;
    public float yLowerBound = -4f;
    public float yUpperBound = 5f;
    public double shootingCooldown = 0.1;
    public double damageCooldown = 1;
    public double deathTime = 1;
    public GameObject playerProjectileObject;
    public Animator animator;
    InputAction move;
    InputAction dash;
    InputAction shoot;
    double shootingTimer = 0;
    Vector3 velocity;
    Vector3 preDashVelocity;
    bool moving = false;
    bool dashing = false;
    bool shooting = true;
    bool takingDamage = false;
    double damageTimer = 0;
    bool dying = false;
    double deathTimer = 0;
    public AudioSource dashSound;
    public AudioSource deathSound;
    public GameObject GameOverScreen;
    public CapsuleCollider2D hitbox;

    public double dashIFrames = 0.5;
    public double dashTimer;
    public bool dashingInv = false;
    public double dashCooldown = 1;
    public double currentCooldown = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (InputSystem.actions)
        {
            // movement input setup
            move = InputSystem.actions.FindAction("Move");
            move.performed += onMove;
            move.canceled += onCancelMove;
            move.Enable();

            // dash input setup
            dash = InputSystem.actions.FindAction("Dash");
            dash.performed += onDash;
            dash.Enable();

            // // shoot input setup
            // shoot = InputSystem.actions.FindAction("Shoot");
            // shoot.performed += onShoot;
            // shoot.canceled += onCancelShoot;
            // shoot.Enable();
        }
    }

    void onMove(InputAction.CallbackContext context)
    {
        Debug.Log("moving");
        Vector2 input = context.ReadValue<Vector2>();
        if (dashing)
        {
            preDashVelocity = new Vector3(input.x, input.y, 0);
        }
        else
        {
            velocity = new Vector3(input.x, input.y, 0);
            moving = true;
        }
    }

    void onCancelMove(InputAction.CallbackContext context)
    {
        if (dashing)
        {
            preDashVelocity = new Vector3();
        }
        else
        {
            moving = false;
        }
    }

    void onDash(InputAction.CallbackContext context)
    {
        if ((!moving || dashing)) return;
        if (currentCooldown <= 0)
        {
            moving = false;
            dashing = true;
            dashSound.Play();
            preDashVelocity = velocity;
            velocity = velocity.normalized * dashFactor;
            dashingInv = true;
            animator.SetBool("Dashing", true);
            currentCooldown = dashCooldown;
        }
            
    }

    // void onShoot(InputAction.CallbackContext context)
    // {
    //     shooting = true;
    //     shootingTimer = 0;
    //     Debug.Log("lsdkfjalsdkj");
    // }

    // void onCancelShoot(InputAction.CallbackContext context)
    // {
    //     shooting = false;
    //     shootingTimer = 0;
    //     Debug.Log("BURGERBURGERBURGERBURGERBURGER");
    // }

    void shootProjectile()
    {
        GameObject newObject = GameObject.Instantiate(playerProjectileObject, transform.position + new Vector3(0, 1.1F, 0), Quaternion.identity);
        newObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * 10;
    }

    // Update is called once per frame
    void Update()
    {
        currentCooldown -= Time.fixedDeltaTime;
        if (dying)
        {
            deathTimer += Time.deltaTime;
            if (deathTimer > deathTime)
            {
                Debug.Log("player has died officially");
                Instantiate(GameOverScreen, new Vector3(), Quaternion.identity);
                Destroy(gameObject);
            }
        }

        if (shooting)
        {
            shootingTimer += Time.deltaTime;
            if (shootingTimer > shootingCooldown)
            {
                shootingTimer = 0;
                shootProjectile();
                Debug.Log(
                    "Projectile Fired"
                );
            }
        }

        if (takingDamage)
        {
            damageTimer += Time.deltaTime;
            if (damageTimer > damageCooldown)
            {
                damageTimer = 0;
                takingDamage = false;
            }
        }

        Vector3 newPosition = transform.position + velocity * Time.deltaTime * speed;
        if (newPosition.x < xLowerBound || newPosition.x > xUpperBound)
        {
            velocity.x = 0;
        }
        if (newPosition.y < yLowerBound || newPosition.y > yUpperBound)
        {
            velocity.y = 0;
        }
        transform.position = transform.position + velocity * Time.deltaTime * speed;
        if (moving) return;
        if (dashing ? velocity.magnitude > preDashVelocity.magnitude : velocity.magnitude > friction)
        {
            velocity -= velocity.normalized * friction;
        }
        else if (dashing)
        {
            velocity = preDashVelocity;
            moving = true;
            dashing = false;
        }
        else
        {
            velocity = new Vector3();
        }

        if (dashIFrames > dashTimer && dashingInv)
        {
            dashTimer += Time.deltaTime;
            hitbox.enabled = false;
            if (dashTimer > 0.208)
            {
                animator.SetBool("Dashing", false);
            }
        }
        else
        {
            dashTimer = 0;
            hitbox.enabled = true;
            dashingInv = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.name);
        if (takingDamage) return;
        if (col.name == "Projectile(Clone)" || col.name == "Yellow Beam(Clone)" || col.name == "CratePrefab(Clone)" || col.name == "StackedCratesPrefab(Clone)")
        {
            GameObject uiObject = GameObject.FindWithTag("UI");
            uiObject.GetComponent<PlayerHealth>().takeDamage(1);
            takingDamage = true;
            animator.SetTrigger("Hit");
        }
    }

    public void OnDeath()
    {
        Debug.Log("PLAYER DIED");
        transform.position = transform.position + new Vector3(0, 1, 0);
        animator.SetTrigger("Dead");
        deathSound.Play();
        dying = true;
    }
}

