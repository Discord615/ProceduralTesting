using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one instance of " + instance.name);
            Destroy(instance);
        }
        instance = this;
    }

    Vector2 movementPressed;

    public void MovementPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            movementPressed = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            movementPressed = context.ReadValue<Vector2>();
        }
    }

    public Vector2 getMovementPressed()
    {
        return movementPressed;
    }

    bool runPressed;

    public void RunPressed(InputAction.CallbackContext context)
    {
        if (context.performed) runPressed = true;
        else if (context.canceled) runPressed = false;
    }

    public bool getRunPressed()
    {
        return runPressed;
    }
}
