using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustBody : MonoBehaviour
{
    [SerializeField] Transform LeftLeg, RightLeg;

    private void FixedUpdate()
    {
        float smoothedPositionY = Mathf.Lerp(transform.position.y, getLowestFeetHeight(), 0.250f);
        transform.position = new Vector3(transform.position.x, smoothedPositionY, transform.position.z);
    }

    private float getLowestFeetHeight()
    {
        float lowestFeet = RightLeg.position.y <= LeftLeg.position.y ? RightLeg.position.y : LeftLeg.position.y;
        return lowestFeet - 0.04f;
    }
}
