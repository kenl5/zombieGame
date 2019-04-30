using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2Controller : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody myRigidBody;

    private AudioSource bulletFiring;

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
        bulletFiring = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
         moveInput = new Vector3(Input.GetAxis("Horizontal1"), 0f, Input.GetAxis("Vertical1"));
        transform.rotation = Quaternion.LookRotation(moveInput);
        transform.Translate(moveInput * moveSpeed * Time.deltaTime, Space.World);

        if (Input.GetKeyDown(KeyCode.K))
        {
            gun.firing = true;
            bulletFiring.Play();
            bulletFiring.loop = (true);
        }

        if (Input.GetKeyUp(KeyCode.K))
        {
            gun.firing = false;
            bulletFiring.Stop();
            bulletFiring.loop = (false);
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

