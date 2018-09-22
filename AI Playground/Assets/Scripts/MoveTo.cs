using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    #region PUBLIC_VARIABLES
    public Transform target = null;

    public float speed = 1.0f;
    public float rotationAngle = 90.0f;
    public float maxDistanceAway = 5.0f;

    public enum MoveToState { chaseTarget, escapeFromTarget };
    public MoveToState moveToState = MoveToState.chaseTarget;
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
        if (Input.GetButtonDown("Jump"))
        {
            if (moveToState == MoveToState.chaseTarget)
                moveToState = MoveToState.escapeFromTarget;
            else
                moveToState = MoveToState.chaseTarget;
        }
    }

    void FixedUpdate()
    {
        // Calculate direction
        Vector3 dir = Vector3.zero;

        switch (moveToState)
        {
            case MoveToState.chaseTarget:

                dir = target.position - thisTransform.position;
                break;

            case MoveToState.escapeFromTarget:

                dir = -(target.position - thisTransform.position);
                break;

            default:
                break;
        }

        dir.y = 0.0f;
        dir.Normalize();

        // 1. Rotate
        Quaternion destinationRot = Quaternion.LookRotation(dir, Vector3.up);
        thisTransform.rotation = Quaternion.RotateTowards(thisTransform.rotation, destinationRot, rotationAngle * Time.deltaTime);

        // 2. Move
        Vector3 velocity = Vector3.zero;

        switch (moveToState)
        {
            case MoveToState.chaseTarget:

                velocity = dir * speed;
                thisTransform.position += velocity * Time.deltaTime;
                break;

            case MoveToState.escapeFromTarget:

                if (Vector3.Distance(target.position, thisTransform.position) < maxDistanceAway)
                {
                    velocity = dir * speed;
                    thisTransform.position += velocity * Time.deltaTime;
                }
                break;

            default:
                break;
        }   
    }
    #endregion
}
