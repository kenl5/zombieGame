using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun2Controller : MonoBehaviour
{

    public bool firing;

    public bulletController bullet;
    public float speed;

    public float fireRate;
    private float shotCounter;

    public Transform firePoint;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (firing)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = fireRate;
                bulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
                newBullet.speed = speed;
            }
        }

        else
        {
            shotCounter = 0;
        }
    }
}
