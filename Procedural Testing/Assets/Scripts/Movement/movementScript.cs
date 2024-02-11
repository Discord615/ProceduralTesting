using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    public static movementScript instance { get; private set; }

    [Header("Essential Variables")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float acceleration = 2f;
    [SerializeField] float decceleration = 2f;
    [SerializeField] float currentSpeed = 0f;
    [SerializeField] float rotationSpeed = 360;
    [SerializeField] GameObject mainBody;
    public Vector2 moveDirection { get; private set; } = Vector2.zero;
    Vector3 currentDirection = new Vector3();

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one instance of " + instance.name);
            Destroy(instance);
        }
        instance = this;
    }

    private void Update()
    {
        moveDirection = InputManager.instance.getMovementPressed();

        rotate();
        speedControl();

        if (move() != Vector3.zero) currentDirection = move();

        transform.Translate(currentDirection * (moveSpeed * (currentSpeed * (InputManager.instance.getRunPressed() ? 1.5f : 1))) * Time.deltaTime);
    }

    private void speedControl()
    {
        if (moveDirection != Vector2.zero)
        {
            currentSpeed += acceleration * Time.deltaTime;
            if (currentSpeed >= moveSpeed - 0.05f) currentSpeed = moveSpeed;
        }
        else
        {
            currentSpeed -= decceleration * Time.deltaTime;
            if (currentSpeed <= 0.05f) currentSpeed = 0;
        }
    }

    private Vector3 move()
    {
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;

        Vector3 forwardRelativeVertical = moveDirection.y * forward, rightRelativeVertical = moveDirection.x * right;

        Vector3 cameraRelativeMovement = forwardRelativeVertical + rightRelativeVertical;

        return cameraRelativeMovement;
    }

    private void rotate()
    {
        if (moveDirection != Vector2.zero)
        {
            Vector3 moveDirectionV3 = new Vector3(move().x, 0, move().z);
            Quaternion rotation = Quaternion.LookRotation(moveDirectionV3, Vector3.up);

            mainBody.transform.rotation = Quaternion.RotateTowards(mainBody.transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
    }



    public float getCurrentSpeed()
    {
        return currentSpeed;
    }
}
