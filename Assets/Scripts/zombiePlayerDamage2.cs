using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombiePlayerDamage2: MonoBehaviour

{

    public int damage = 10;

    void Start()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {

            collision.gameObject.GetComponent<enemyHealth>().enemyHit(damage);
            //collision.gameObject.GetComponent<zombiePlayer2Controller>().zpRoar.Play();
        }
        else if (collision.gameObject.name == "PlayerBody")
        {
            collision.gameObject.transform.parent.GetComponent<playerHealth>().HurtPlayer(damage);
        }
    }


}
