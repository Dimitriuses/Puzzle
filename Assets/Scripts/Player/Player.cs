using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera PlayerCamera;
    public float Sensitivity;

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Sensitivity);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Sensitivity);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Sensitivity);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Sensitivity);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            yaw -= speedH;
        }
        if (Input.GetKey(KeyCode.E))
        {
            yaw += speedH;
        }
        //yaw += speedH * Input.GetAxis("Mouse X");
        //pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
        //PlayerCamera.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);


    }

    

    private void Move()
    {
        
    }
}
