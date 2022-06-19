using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    public int speed;
    
    Rigidbody physic;

    private void Start()
    {
        physic = GetComponent<Rigidbody>();
        //Random Vector3 value for rotation
        physic.angularVelocity = Random.insideUnitSphere * speed;
    }

}
