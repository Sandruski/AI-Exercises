using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawAxes : MonoBehaviour
{
    public float range = 1.0f;

    void OnDrawGizmos()
    {
        // Local axes
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * range);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * range);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + transform.up * range);
    }
}
