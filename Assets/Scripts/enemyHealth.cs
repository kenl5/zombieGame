using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class enemyHealth : MonoBehaviour {
    public GameObject itemDrop;
    public float health;
    public float currentHealth;
    float dropRate = 0.05f;
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
            if(Random.Range(0f,1f) <= dropRate)
            {
                var pickUp = Instantiate(itemDrop, gameObject.transform.position, Quaternion.identity);
            }
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
