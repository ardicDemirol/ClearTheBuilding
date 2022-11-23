using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody myRigidbody;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpPower = 5f;
    [SerializeField] float turnSpeed = 5f;
    [SerializeField] private Transform[] rayStartPoints;



    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        TakeInput();
        Debug.Log(OnGroundCheck());
    }

    private void TakeInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && OnGroundCheck())
        {
            myRigidbody.velocity = new Vector3(myRigidbody.velocity.x,Mathf.Clamp((jumpPower * 100) * Time.deltaTime,0f,15f),0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            myRigidbody.velocity = new Vector3(Mathf.Clamp((-speed * 100) * Time.deltaTime,-15f,0f), myRigidbody.velocity.y, 0f);

            //transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 90f, 0f), turnSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            myRigidbody.velocity = new Vector3(Math.Clamp((speed * 100) * Time.deltaTime,0f,15f), myRigidbody.velocity.y, 0f);
           
            //transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, -90f, 0f), turnSpeed * Time.deltaTime);

        }
        else
        {
            myRigidbody.velocity = new Vector3(0f,myRigidbody.velocity.y,0f);
            
        }

    }

    private bool OnGroundCheck()
    {
        bool hit = false;
        for (int i = 0; i < rayStartPoints.Length; i++)
        {
            hit = Physics.Raycast(rayStartPoints[i].position, -rayStartPoints[i].transform.up, 0.50f);
            Debug.DrawRay(rayStartPoints[i].position, -rayStartPoints[i].transform.up * 0.50f, Color.red);  //Raycastin nerede oldu

        }

        if (hit)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
