using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCamera : MonoBehaviour
{
    [SerializeField] Transform target;


    void LateUpdate()
    {
        transform.position = target.position;
    }
}
