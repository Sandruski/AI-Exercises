using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    #region PUBLIC_VARIABLES
    public float speed = 1.0f;
    public float rotationAngle = 90.0f;
    #endregion

    #region PRIVATE_VARIABLES
    private Transform thisTransform = null;

    private float horizontalAxis = 0.0f;
    private float verticalAxis = 0.0f;

    private Vector3 moveDir = Vector3.zero;
    private Vector3 rotateDir = Vector3.zero;
    #endregion

    #region UNITY_CALLBACKS
    void Awake()
    {
        thisTransform = GetComponent<Transform>();
    } 

    void Update()
    {
        horizontalAxis = Input.GetAxisRaw("Horizontal");
        verticalAxis = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // Directions
        moveDir = new Vector3(0.0f, 0.0f, verticalAxis); // local space
        moveDir = thisTransform.rotation * moveDir; // world space
        rotateDir = new Vector3(0.0f, horizontalAxis, 0.0f);

        // 1. Rotate
        thisTransform.rotation *= Quaternion.AngleAxis(rotationAngle * Time.deltaTime, rotateDir);

        // 2. Move
        Vector3 velocity = moveDir * speed;
        thisTransform.position += velocity * Time.deltaTime;
    }
    #endregion
}
