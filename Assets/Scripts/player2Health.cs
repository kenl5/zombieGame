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

    // Use this for initialization
    void Start()
    {
        currentHealth = startHealth;
        rend = GetComponent<Renderer>();
        storedColor = rend.material.GetColor("_Color");

        healthBar.value = healthPercentage();

        //use for timer
        startTime = Time.time;
    }


    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            done = true;
            gameObject.SetActive(false);

        }

        if (flashCount > 0)
        {
            flashCount -= Time.deltaTime;
            if (flashCount <= 0)
            {
                rend.material.SetColor("_Color", storedColor);
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
        rend.material.SetColor("_Color", Color.red);
    }
}
