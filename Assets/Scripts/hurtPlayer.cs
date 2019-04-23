using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtPlayer : MonoBehaviour {

    public int damage;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<playerHealth>().HurtPlayer(damage);
        }
        else
        {
            other.gameObject.GetComponent<player2Health>().HurtPlayer(damage); //set second player's tag to "Player2"
        }
    }
}
