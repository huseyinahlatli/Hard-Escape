using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    Rigidbody physics;

    void Start()
    {
        physics = GetComponent<Rigidbody>();
        physics.angularVelocity = new Vector3(0, rotateSpeed, 0);
    }
}
