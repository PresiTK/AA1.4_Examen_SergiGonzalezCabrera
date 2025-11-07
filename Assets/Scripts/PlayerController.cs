using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public float speed;
    public float speedRotation;
    public Transform target;
    private Rigidbody rb;
    private Vector3 velocityChange= Vector3.zero;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    void FixedUpdate()
    {
        float vertical = 0f;
        float horizontal = 0f;

        if (Keyboard.current == null)
        {
        }
        else
        {
            if (Keyboard.current.wKey.isPressed)
            {
                vertical += 1f;
                Debug.Log("W");
            }
            if (Keyboard.current.sKey.isPressed)
            {
                vertical -= 2f;
                Debug.Log("S");
            }
            if (Keyboard.current.aKey.isPressed)
            {
                horizontal -= 1f;
                Debug.Log("A");
            }
            if (Keyboard.current.dKey.isPressed)
            {
                horizontal += 1f;
                Debug.Log("D");
            }
        }
        Vector3 direction = (transform.forward * vertical + transform.right * horizontal).normalized;

        if (direction == Vector3.zero)
        {
        }
        else
        {

            Vector3 firstVelocity = direction * speed;
            Vector3 finalVelocity = rb.linearVelocity;
            velocityChange = firstVelocity - new Vector3(finalVelocity.x, 0f, finalVelocity.z);

            rb.AddForce(velocityChange, ForceMode.VelocityChange);
        }
    }
}
