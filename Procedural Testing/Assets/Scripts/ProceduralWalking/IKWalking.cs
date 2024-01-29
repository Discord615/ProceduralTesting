using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKWalking : MonoBehaviour
{
    [SerializeField] private IKWalking OtherLeg;

    Vector3 currentPos, newPos, oldPos;
    [SerializeField] private Transform target, idleTarget, capFollow;

    bool grounded, isIdle = true;
    [SerializeField] private float stepDistance = 1f, stepHeight = 1f, stepSpeed = 3f, idleLegOffset;
    float lerp = 1;

    private void Start()
    {
        currentPos = newPos = oldPos = target.position;
        currentPos.z = 0;
    }

    private void Update()
    {
        transform.position = currentPos;

        if (Vector3.Distance(transform.position, target.position) > stepDistance && lerp >= 1 && OtherLeg.isGrounded())
        {
            lerp = 0;
            newPos = target.position;

            // Debug.Log(gameObject.name + ": Moving");
        }

        // ! TO BE FIXED
        // if (Vector3.Distance(transform.position, capFollow.position) < 0.5f && lerp >= 1 && !isIdle)
        // {
        //     isIdle = true;
        //     lerp = 0;
        //     newPos = idleTarget.position;

        //     Debug.Log(gameObject.name + ": Idle");
        // }

        if (lerp < 1)
        {
            Vector3 footPos = Vector3.Lerp(oldPos, newPos, lerp);
            footPos.y += Mathf.Sin(lerp * Mathf.PI) * stepHeight;
            currentPos = footPos;
            lerp += Time.deltaTime * ((Vector3.Distance(transform.position, capFollow.position) * 2) + stepSpeed);
            grounded = false;
        }
        else
        {
            oldPos = newPos;
            grounded = true;
        }
    }

    public bool isGrounded()
    {
        return grounded;
    }
}
