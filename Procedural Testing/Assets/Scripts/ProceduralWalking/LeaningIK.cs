using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaningIK : MonoBehaviour
{
    [SerializeField] private Transform leftLeg, rightLeg;
    Vector3 leaningTarget;

    private void Start()
    {
        leaningTarget = transform.position;
    }

    private void Update()
    {
        leaningTarget = (leftLeg.localPosition + rightLeg.localPosition) / 2;
        leaningTarget.y = 5;

        Vector3 smoothedPos = Vector3.Lerp(transform.localPosition, new Vector3(-leaningTarget.x, leaningTarget.y, -leaningTarget.z), 0.025f);
        transform.localPosition = smoothedPos;
    }
}
