using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zombiePlayerController : MonoBehaviour
{

    public float zpMoveSpeed;
    private Rigidbody zpRigidBody;

    private Vector3 zpMoveInput;
    private Vector3 zpMoveVelo;

    public AudioSource zpRoar;

    private Camera zpMainCam;

    public int zpDamage;

    public float zpTimer;

    public playerHealth health;

    public GameObject player2;


    // Use this for initialization
    void Start()
    {

        zpRigidBody = GetComponent<Rigidbody>();
        zpMainCam = FindObjectOfType<Camera>();
        health = this.transform.parent.GetComponent<playerHealth>();
        player2 = GameObject.Find("Player2");
        zpRoar = gameObject.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        zpTimer -= Time.deltaTime;

        if(player2.gameObject.GetComponent<player2Health>().dead == true)
        {
            Application.Quit();
        }

        if (zpTimer < 0)
        {
            gameObject.SetActive(false);

        }
        zpMoveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        if (zpMoveInput != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(zpMoveInput);
            transform.Translate(zpMoveInput * zpMoveSpeed * Time.deltaTime, Space.World);
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
        zpRigidBody.velocity = zpMoveVelo;
    }
}
