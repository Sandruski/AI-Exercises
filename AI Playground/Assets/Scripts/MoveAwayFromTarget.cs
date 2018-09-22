using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAwayFromTarget : MonoBehaviour
{
    #region PUBLIC_VARIABLES
    public Transform target = null;

    public float speed = 10.0f;
    public float rotationAngle = 90.0f;
    public float maxDistanceAway = 10.0f;
    #endregion

    #region PRIVATE_VARIABLES
    private Transform thisTransform = null;
    #endregion

    #region UNITY_CALLBACKS
    void Awake()
    {
        thisTransform = GetComponent<Transform>();
    }

    void Update()
    {
        // Calculate direction
        Vector3 dir = thisTransform.position - target.position;
        dir.y = 0.0f;
        dir.Normalize();

        // 1. Rotate
        Quaternion destinationRot = Quaternion.LookRotation(dir, Vector3.up);
        thisTransform.rotation = Quaternion.RotateTowards(thisTransform.rotation, destinationRot, rotationAngle * Time.deltaTime);

        // 2. Move
        if (Vector3.Distance(target.position, thisTransform.position) < maxDistanceAway)
        {
            Vector3 moveVelocity = dir * speed;
            thisTransform.position += moveVelocity * Time.deltaTime;
        }
    }
    #endregion
}
