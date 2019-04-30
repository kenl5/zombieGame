using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour {

    private Rigidbody RB;
    public float speed;

    public GameObject player;
    public GameObject player2;
    private float dist1;
    private float dist2;

	// Use this for initialization
	void Start () {
        RB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        player2 = GameObject.Find("Player2");



    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver())
        {
            return;
        }

        if (PlayerStats()==0)
        {
            dist1 = Vector3.Distance(player.transform.GetChild(0).transform.position, transform.position);
            dist2 = Vector3.Distance(player2.transform.GetChild(0).transform.position, transform.position);
            if (dist1 < dist2)
            {
                transform.LookAt(player.transform.GetChild(0).position);
            }
            else if (dist2 < dist1)
                transform.LookAt(player2.transform.GetChild(0).position);

        }
        else if (PlayerStats() == 1)
        {
            transform.LookAt(player2.transform.GetChild(0).position);
        }
        else if (PlayerStats() == 2)
        {
            transform.LookAt(player.transform.GetChild(0).position);
        }
        else
        {
            return;
        }
    }

    private void FixedUpdate()
    {
        RB.velocity = (transform.forward * speed);
    }

    private bool GameOver()
    {
        if (player != null || player2 != null)
        {
            return false;
        }
        else if(player.transform.GetChild(0).gameObject.activeSelf || player.transform.GetChild(0).gameObject.activeSelf)
        {
            return false;
        }
        return false;
    }

    private int PlayerStats() 
    {
        bool player1dead = player.GetComponent<playerHealth>().dead;
        bool player2dead = player2.GetComponent<player2Health>().dead;
        if (!player1dead && !player2dead)
        {
            return 0;
        }
        else if (player1dead && !player2dead)
        {
            return 1;
        }
        else if (!player1dead && player2dead)
        {
            return 2;
        }
        else
        {
            return -1;
        }
    }

}
