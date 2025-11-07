using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    public float speedRotation;
    public float stoppingDistance;
    public float speed = 2f;
    private Rigidbody rb;
    private Vector3 velocityChange;


    [SerializeField] private GameObject target;
    private Vector3 targetPos;
    private void Start()
    {
        rb= GetComponent<Rigidbody>();  
        target = GameObject.FindGameObjectWithTag("Player");
    }
    private void FixedUpdate()
    {
        LookAtObject();
        Vector3 direction = (transform.forward * 1 + transform.right * 0).normalized;
        Vector3 firstVelocity = direction * speed;
        Vector3 finalVelocity = rb.linearVelocity;
        velocityChange = firstVelocity - new Vector3(finalVelocity.x, 0f, finalVelocity.z);
        rb.AddForce(velocityChange, ForceMode.VelocityChange);
        if((target.transform.position.x-transform.position.x<3) && (target.transform.position.x - transform.position.x > -3)&& (target.transform.position.z - transform.position.z < 3) && (target.transform.position.z - transform.position.z > -3))
        {
            speed = 1f;
        }
        else
        {
            speed = 2f;
        }
            Debug.Log(target.transform.position.x - transform.position.x);

    }
    private void Update()
    {

    }

    public void Kill()
    {

    }
    private void LookAtObject()
    {
        targetPos.x=target.transform.position.x;
        targetPos.z = target.transform.position.z;

        transform.LookAt(targetPos);
    }
}
