using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public int speed = 20;
    public float dashFactor = 5F;
    public float friction = 0.01F;

    InputAction move;
    InputAction dash;
    Vector3 velocity;
    Vector3 preDashVelocity;
    bool moving = false;
    bool dashing = false;


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
        }
    }

    void onMove(InputAction.CallbackContext context)
    {
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
        Debug.Log("called dash");
        if (!moving || dashing) return;
        Debug.Log("dashing");
        moving = false;
        dashing = true;
        preDashVelocity = velocity;
        velocity = velocity.normalized * dashFactor;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime * speed;
        if (moving) return;
        if (dashing ? velocity.magnitude > preDashVelocity.magnitude : velocity.magnitude > friction)
        {
            Debug.Log("applying friction");
            velocity -= velocity.normalized * friction;
        }
        else if (dashing)
        {
            Debug.Log("applying dash");
            velocity = preDashVelocity;
            moving = true;
            dashing = false;
        }
        else
        {
            Debug.Log("stopping");
            velocity = new Vector3();
        }
        Debug.Log("new velocity: " + velocity);
    }
}
