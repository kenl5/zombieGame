using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2Controller : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody myRigidBody;

    private Vector3 moveInput;
    private Vector3 moveVelo;

    private Camera mainCam;

    public gunController gun;
    public GameObject wall;
    private int wallCount;

    // Use this for initialization
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        mainCam = FindObjectOfType<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        
         moveInput = new Vector3(Input.GetAxis("Horizontal1"), 0f, Input.GetAxis("Vertical1"));
        // moveVelo = moveInput * moveSpeed;

        //Ray camRay = mainCam.ScreenPointToRay(Input.mousePosition);
        //Plane ground = new Plane(Vector3.up, Vector3.zero);
        //float rayLength;

        //if (ground.Raycast(camRay, out rayLength))
        //{
        //    Vector3 pointToLook = camRay.GetPoint(rayLength);
        //    Debug.DrawLine(camRay.origin, pointToLook, Color.blue);

        //    transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        //}

        transform.rotation = Quaternion.LookRotation(moveInput);
        transform.Translate(moveInput * moveSpeed * Time.deltaTime, Space.World);

        if (Input.GetKeyDown(KeyCode.K))
        {
            gun.firing = true;
        }

        if (Input.GetKeyUp(KeyCode.K))
        {
            gun.firing = false;
        }
        if (Input.GetKeyDown(KeyCode.L) && wallCount < 5)
        {
            Instantiate(wall, transform.position, Quaternion.identity);
            wallCount++;
        }
    }

    private void FixedUpdate()
    {
        myRigidBody.velocity = moveVelo;
    }
}

