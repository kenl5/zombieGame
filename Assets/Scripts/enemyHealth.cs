using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class enemyHealth : MonoBehaviour {

    public float health;
    public float currentHealth;

    public Slider healthBar;
	// Use this for initialization
	void Start () {
        currentHealth = health;
	}
	
	// Update is called once per frame
	void Update () {
		if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
	}

    float healthPercentage()
    {
        return currentHealth / health;
    }

    public void enemyHit(int damage)
    {
        currentHealth -= damage;
        healthBar.value = healthPercentage();

    }
}
