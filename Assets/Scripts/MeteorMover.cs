using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMover : MonoBehaviour
{
    Rigidbody physic;


    private void Start()
    {
        physic = GetComponent<Rigidbody>();

        physic.velocity = transform.forward * GameController.instance.meteorSpeed;
    }

}
