using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    NavMeshAgent navMesh;

    private void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveToCursor();
        }
    }


    private void MoveToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);
        if (hasHit)
        {
            navMesh.destination = hit.point;
        }
    }

    private void UpdateAnimator()
    {
        float speed = 0;
        if (navMesh.remainingDistance > 0)
        {
            Vector3 velocity = navMesh.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            speed = localVelocity.z;
        }
        GetComponent<Animator>().SetFloat("forwardSpeed", speed);
    }
}
