using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCap : MonoBehaviour
{
    [SerializeField] Transform target, LeftLeg, RightLeg;

    [SerializeField] float smoothSpeed = 0.025f;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position;

        desiredPosition.y = getLowestFeetHeight();

        float smoothedPositionX = Mathf.Lerp(transform.position.x, desiredPosition.x, smoothSpeed);
        float smoothedPositionZ = Mathf.Lerp(transform.position.z, desiredPosition.z, smoothSpeed);
        transform.position = new Vector3(smoothedPositionX, desiredPosition.y, smoothedPositionZ);

        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
    }

    private float getLowestFeetHeight()
    {
        float lowestFeet = RightLeg.position.y <= LeftLeg.position.y ? RightLeg.position.y : LeftLeg.position.y;
        return lowestFeet - 0.04f;
    }
}
