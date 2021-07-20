using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    NavMeshAgent navAgent;

    private void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
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
        navAgent.speed = Input.GetKey(KeyCode.LeftShift) ? 6 : 4.5f;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);
        if (hasHit)
        {
            navAgent.destination = hit.point;
        }
    }

    private void UpdateAnimator()
    {
        float speed = 0;
        if(navAgent.remainingDistance > 0)
        {
            Vector3 velocity = navAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            speed = localVelocity.z;
        }
        GetComponent<Animator>().SetFloat("forwardMotion", speed);

    }
}
