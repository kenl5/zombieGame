using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour {

    public float speed;

    public float bulletTime;

    public int damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        bulletTime -= Time.deltaTime;
        if (bulletTime <= 0)
        {
            Destroy(gameObject);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Zombie")
        {
            collision.gameObject.GetComponent<enemyHealth>().enemyHit(damage);
            Destroy(gameObject);
        }
    }
}
