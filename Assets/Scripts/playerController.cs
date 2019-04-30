using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

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
	void Start () {
        myRigidBody = GetComponent<Rigidbody>();
        mainCam = FindObjectOfType<Camera>();
        wallCount = 0;
        bulletFiring = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        if (moveInput != Vector3.zero){
            transform.rotation = Quaternion.LookRotation(moveInput);
            transform.Translate(moveInput * moveSpeed * Time.deltaTime, Space.World);
        }
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            gun.firing = true;
            bulletFiring.Play();
            bulletFiring.loop = (true);
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            gun.firing = false;
            bulletFiring.Stop();
            bulletFiring.loop = (false);
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
