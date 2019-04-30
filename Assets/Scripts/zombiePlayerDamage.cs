using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombiePlayerDamage : MonoBehaviour

{

    public int damage = 10;

    void Start()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Zombie")
        {

            collision.gameObject.GetComponent<enemyHealth>().enemyHit(damage);
            //collision.gameObject.GetComponent<zombiePlayerController>().zpRoar.Play();
        }
        else if(collision.gameObject.name == "Player2Body")
        {
            collision.gameObject.transform.parent.GetComponent<player2Health>().HurtPlayer(damage);
        }
    }


}
