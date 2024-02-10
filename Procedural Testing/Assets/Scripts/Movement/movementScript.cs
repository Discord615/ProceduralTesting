using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    [Header("Essential Variables")]
    [SerializeField] float moveSpeed = 5f;
    public Vector2 moveDirection { get; private set; } = Vector2.zero;

    private void Update()
    {
        moveDirection = InputManager.instance.getMovementPressed();

        transform.Translate(move() * (moveSpeed * (InputManager.instance.getRunPressed() ? 2f : 1)) * Time.deltaTime);
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
}
