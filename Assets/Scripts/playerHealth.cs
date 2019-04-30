using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;


public class playerHealth : MonoBehaviour {

    public float startHealth;
    public float currentHealth;

    public float hurtTime;
    private float flashCount;

    private bool done = false;
    private Renderer rend;
    private Color storedColor;

    public Slider healthBar;

    //use for timer
    public Text timerText;
    public Text endText;
    private float startTime;

    public GameObject ZombieBody;
    public GameObject PlayerBody;

    public GameObject player2;

    public bool dead = false;
    public bool zombied = false;

    public GameObject Body
    {
        get
        {
            if (PlayerBody.activeInHierarchy)
                return PlayerBody;
            else
                return ZombieBody;
        }
        set
        {
            if (PlayerBody.activeInHierarchy)
                PlayerBody = value;
            else
                ZombieBody = value;
        }
    }

    // Use this for initialization
    void Start () {
        currentHealth = startHealth;

        player2 = GameObject.Find("Player2");

        Body = transform.Find("PlayerBody").gameObject;

        storedColor = Body.GetComponent<Renderer>().material.GetColor("_Color");

        healthBar.value = healthPercentage();

        //use for timer
        startTime = Time.time;
    }

    public void CreateZombie()
    {
        //Vector3 spawnPosition22 = new Vector3(Body.transform.position.x, 0, Body.transform.position.z);

        PlayerBody.SetActive(false);

        Vector3 spawnPosition22 = new Vector3(PlayerBody.transform.position.x, 0, PlayerBody.transform.position.z);

        ZombieBody.transform.position = spawnPosition22;

        ZombieBody.SetActive(true);
        zombied = (true);

    }


    // Update is called once per frame
    void Update () {
        if (currentHealth <= 0)
        {
            dead = (true);
            if (player2.GetComponent<player2Health>().dead == false)
            {

                if(!zombied)
                    CreateZombie();

            }
            else
            {
                done = (true);
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }


        }
        if (!dead)
        {
            if (flashCount > 0)
            {
                flashCount -= Time.deltaTime;
                if (flashCount <= 0)
                {
                    Body.GetComponent<Renderer>().material.SetColor("_Color", storedColor);
                }
            }
        }


        //use for timer
        if (done)
        {
            endText.color = Color.red;
            endText.text = "you survived: " + timerText.text;
            return;
        }
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;

    }

    // For players to pick up the items

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HP")
        {
            currentHealth += 1;
            if (currentHealth > startHealth)
            {
                currentHealth = startHealth;
            }
            Destroy(other.gameObject);
            healthBar.value = healthPercentage();
            flashCount = hurtTime;
            Body.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
        if(other.tag == "weapon")
        {
            Destroy(other.gameObject);
            if (gunController.fireRate > 0.05)
            {
                gunController.fireRate *= 0.7f;
            }
        }
    }


    float healthPercentage()
    {
        return currentHealth / startHealth;
    }

    public void HurtPlayer(int damage)
    {
        currentHealth -= damage;
        healthBar.value = healthPercentage();
        flashCount = hurtTime;
        Body.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }
}
