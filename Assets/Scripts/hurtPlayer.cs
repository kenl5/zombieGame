using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtPlayer : MonoBehaviour {

    public int damage;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "PlayerBody")
        {
            
            other.gameObject.transform.parent.GetComponent<playerHealth>().HurtPlayer(damage);
        }
        else if(other.gameObject.name == "Player2Body")
        {
            other.gameObject.transform.parent.GetComponent<player2Health>().HurtPlayer(damage);
        }

        else
        {
            //other.gameObject.GetComponent<player2Health>().HurtPlayer(damage); //set second player's tag to "Player2"
        }
    }
}
