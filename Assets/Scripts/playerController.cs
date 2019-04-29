﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody myRigidBody;

    private Vector3 moveInput;
    private Vector3 moveVelo;

    private Camera mainCam;

    public gunController gun;
    public GameObject wall;
    private int wallCount;

	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody>();
        mainCam = FindObjectOfType<Camera>();
        wallCount = 0;
    }
	
	// Update is called once per frame
	void Update () {
        moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        /*
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
        */
        if (moveInput != Vector3.zero){
            transform.rotation = Quaternion.LookRotation(moveInput);
            transform.Translate(moveInput * moveSpeed * Time.deltaTime, Space.World);
        }
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            gun.firing = true;
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            gun.firing = false;
        }
        if (Input.GetKeyDown(KeyCode.V) && wallCount < 5)
        {
            Instantiate(wall, transform.position, Quaternion.identity);
            wallCount++;
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
