using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Control
{
    public class Movement : MonoBehaviour
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
            UpdateAnimator();
        }

        private void UpdateAnimator()
        {
            float speed = 0;
            if (navMesh.remainingDistance > 0)
            {
                Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
                Vector3 localVelocity = transform.InverseTransformDirection(velocity);
                speed = localVelocity.z;
            }
            animator.SetFloat("forwardSpeed", speed);
        }
    }
}
