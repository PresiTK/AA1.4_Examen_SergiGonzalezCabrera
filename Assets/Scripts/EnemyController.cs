using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    public float speedRotation;
    public float stoppingDistance;

    [SerializeField] private GameObject target;
    private Vector3 targetPos;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
    private void FixedUpdate()
    {
        LookAtObject();
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
