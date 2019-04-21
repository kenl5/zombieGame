using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour {

    private Rigidbody RB;
    public float speed;

    public playerController player;

	// Use this for initialization
	void Start () {
        RB = GetComponent<Rigidbody>();
        player = FindObjectOfType<playerController>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(player.transform.position);
	}

    private void FixedUpdate()
    {
        RB.velocity = (transform.forward * speed);
    }
}
