using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
        print(rigidBody.name);
    }

    // Update is called once per frame
    void Update()
    {
        ProcessImput();
    }

    private void ProcessImput()
    {
        if (Input.GetKey(KeyCode.Space)) // Thrust while rotating
        {
            rigidBody.AddRelativeForce(Vector3.up);
        }

        // Cannot rotate both ways at the same time
        if (Input.GetKey(KeyCode.A))
        {
            print("Rotate Left");
        } 
        else if (Input.GetKey(KeyCode.D))
        {
            print("Rotate Right");
        }
    }
}
