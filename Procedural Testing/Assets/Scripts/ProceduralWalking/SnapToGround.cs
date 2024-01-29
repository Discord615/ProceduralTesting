using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToGround : MonoBehaviour
{
    [SerializeField] private LayerMask terrainLayer;
    private void Update()
    {
        Ray ray = new Ray(transform.position + (Vector3.up * 2), Vector3.down);

        if (Physics.Raycast(ray, out RaycastHit info, 10, terrainLayer.value))
        {
            transform.position = info.point;
        }
    }
}
