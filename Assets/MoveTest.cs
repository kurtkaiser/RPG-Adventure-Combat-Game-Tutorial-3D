using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTest : MonoBehaviour
{
    Animator animator;
    NavMeshAgent navMesh;

    private void Start()
    {
        animator = GetComponent<Animator>();
        navMesh = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveToCursor();
        }
        UpdateAnimator();

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
        Vector3 velocity = navMesh.velocity;
        Debug.Log("x: " + velocity.x + " x: " + velocity.y + " z: " + velocity.z);
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = (localVelocity.z/4) * 0.130319f;
        if (localVelocity.z < 0.05) speed = 0;
        animator.SetFloat("forwardSpeed", speed);

        //   Debug.Log("x: " + velocity.x + " x: " + velocity.y + " z: " + velocity.z);
        // Debug.Log("next x: " + velocity.x + " x: " + velocity.y + " z: " + velocity.z);
        // Vector3 localVelocity = transform.InverseTransformDirection(velocity);

        //  float speed = localVelocity.z;
        // Debug.Log("s: " + speed);
        // if (speed < 0.4) speed = 0;
        // animator.SetFloat("forwardSpeed", 1);

    }

}
