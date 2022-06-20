using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float rocketThrustForce = 1f;
    [SerializeField] float tuneRotationSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotate();
    }    

    void ProcessThrust() 
    {
          if (Input.GetKey(KeyCode.Space))
          {
            rb.AddRelativeForce(Vector3.up * rocketThrustForce * Time.deltaTime);
          }
    }

    void ProcessRotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(tuneRotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
          {
            ApplyRotation(-tuneRotationSpeed);
          }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // Freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation so physics system can take over
    }

}
