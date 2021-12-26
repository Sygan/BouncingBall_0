using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public Transform transform;
    public float paddleSpeed;
    public Rigidbody rigidbody;
    
    private float horizontal = 0f;

    public BallController ball;
    
    public void OnTransformChildrenChanged()
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = Vector3.zero;
        
        transform.position = new Vector3(transform.position.x + horizontal * paddleSpeed * Time.deltaTime, transform.position.y, transform.position.z);
    }
}
