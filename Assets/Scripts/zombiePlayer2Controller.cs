using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zombiePlayer2Controller : MonoBehaviour
{

    public float zpMoveSpeed;
    private Rigidbody zpRigidBody;

    private Vector3 zpMoveInput;
    private Vector3 zpMoveVelo;

    public AudioSource zpRoar;

    private Camera zpMainCam;

    public int zpDamage;

    public float zpTimer;

    public player2Health health;

    public GameObject player;


    // Use this for initialization
    void Start()
    {

        zpRigidBody = GetComponent<Rigidbody>();
        zpMainCam = FindObjectOfType<Camera>();
        health = this.transform.parent.GetComponent<player2Health>();
        player = GameObject.Find("Player");
        zpRoar = gameObject.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        zpTimer -= Time.deltaTime;
        if(player.gameObject.GetComponent<playerHealth>().dead == true)
        {
            Application.Quit();
        }
        if (zpTimer < 0)
        {
            Debug.Log("This is done");
            gameObject.SetActive(false);
        }
        zpMoveInput = new Vector3(Input.GetAxis("Horizontal1"), 0f, Input.GetAxis("Vertical1"));
        transform.rotation = Quaternion.LookRotation(zpMoveInput);
        transform.Translate(zpMoveInput * zpMoveSpeed * Time.deltaTime, Space.World);
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
