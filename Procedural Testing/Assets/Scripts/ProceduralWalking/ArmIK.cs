using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmIK : MonoBehaviour
{
    [SerializeField] private Transform correspondingLeg;
    Vector3 armTarget;
    [SerializeField] private float offest;

    private void Start()
    {
        armTarget = transform.localPosition;
    }

    private void Update()
    {
        armTarget = correspondingLeg.localPosition;
        armTarget.y = transform.localPosition.y;
        armTarget.x = -correspondingLeg.localPosition.x * offest;
        armTarget.z *= 3f;
        armTarget.z -= correspondingLeg.localPosition.z;

        Vector3 smoothedPos = Vector3.Lerp(transform.localPosition, armTarget, 0.125f);
        transform.localPosition = smoothedPos;
    }
}
