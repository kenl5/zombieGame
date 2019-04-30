using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player2Health : MonoBehaviour
{

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

    public GameObject player;

    public GameObject ZombieBody2;
    public GameObject PlayerBody2;

    public bool dead = false;
    public bool zombied = false;

    public GameObject Body2
    {
        get
        {
            if (PlayerBody2.activeInHierarchy)
                return PlayerBody2;
            else
                return ZombieBody2;
        }
        set
        {
            if (PlayerBody2.activeInHierarchy)
                PlayerBody2 = value;
            else
                ZombieBody2 = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        currentHealth = startHealth;
        player = GameObject.Find("Player");

        Body2 = transform.Find("Player2Body").gameObject;

        storedColor = Body2.GetComponent<Renderer>().material.GetColor("_Color");


        healthBar.value = healthPercentage();

        //use for timer
        startTime = Time.time;
    }


    public void CreateZombie2()
    {
        //Vector3 spawnPosition22 = new Vector3(Body.transform.position.x, 0, Body.transform.position.z);

        PlayerBody2.SetActive(false);

        Vector3 spawnPosition22 = new Vector3(PlayerBody2.transform.position.x, 0, PlayerBody2.transform.position.z);

        ZombieBody2.transform.position = spawnPosition22;

        ZombieBody2.SetActive(true);
        zombied = (true);

    }
    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            dead = true;
            if (player.GetComponent<playerHealth>().dead == false)
            {

                if(!zombied)
                {
                    CreateZombie2();
                }


            }
            else
            {
                done = true;
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
                    Body2.GetComponent<Renderer>().material.SetColor("_Color", storedColor);
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

    float healthPercentage()
    {
        return currentHealth / startHealth;
    }

    public void HurtPlayer(int damage)
    {
        currentHealth -= damage;
        healthBar.value = healthPercentage();
        flashCount = hurtTime;
        Body2.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }
}
