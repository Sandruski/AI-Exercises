using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    #region PUBLIC_VARIABLES
    public Transform target = null;

    public float speed = 10.0f;
    public float rotationAngle = 90.0f;
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
        Vector3 dir = target.position - thisTransform.position;
        dir.y = 0.0f;
        dir.Normalize();

        // 1. Rotate
        Quaternion destinationRot = Quaternion.LookRotation(dir, Vector3.up);
        thisTransform.rotation = Quaternion.RotateTowards(thisTransform.rotation, destinationRot, rotationAngle * Time.deltaTime);

        // 2. Move
        Vector3 moveVelocity = dir * speed;
        thisTransform.position += moveVelocity * Time.deltaTime; 
    }
    #endregion
}
