using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody myRigidBody;

    private Vector3 moveInput;
    private Vector3 moveVelo;

    private Camera mainCam;

    public gunController gun;

	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody>();
        mainCam = FindObjectOfType<Camera>();

    }
	
	// Update is called once per frame
	void Update () {
        moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        moveVelo = moveInput * moveSpeed;

        Ray camRay = mainCam.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(ground.Raycast(camRay, out rayLength))
        {
            Vector3 pointToLook = camRay.GetPoint(rayLength);
            Debug.DrawLine(camRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        if(Input.GetMouseButtonDown(0))
        {
            gun.firing = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            gun.firing = false;
        }
	}

    /*
    // For players to pick up the items   
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "HP")
        {
            playerHealth.currentHealth += 2;
            if(playerHealth.currentHealth > playerHealth.startHealth)
            {
                playerHealth.currentHealth = playerHealth.startHealth;
            }
            Destroy(other.gameObject);
        }
    }
    */

    private void FixedUpdate()
    {
        myRigidBody.velocity = moveVelo;
    }
}
