using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonControl : MonoBehaviour
{
    public void singleP()
    {
        playerNumber.n = 1;
        SceneManager.LoadScene("oops");

    }
    public void doubleP(){
        playerNumber.n = 2;
        SceneManager.LoadScene("oops");
    }
    public void quit()
    {
        Application.Quit();
    }
}
