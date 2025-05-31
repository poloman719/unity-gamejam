using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject HealthBar;

    public InputAction testAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        testAction = InputSystem.actions.FindAction("TestAction");
        testAction.performed += ctx => onTest(ctx);
        testAction.Enable();
    }

    void onTest(InputAction.CallbackContext ctx)
    {
        HealthBar.GetComponent<HealthBar>().changeHealth(10 * ctx.ReadValue<float>());
        Debug.Log("test" + ctx);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
