using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int current_lvl;
    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(current_lvl);
        }
    }

    public void next_lvl(int qwerty)
    {
        current_lvl = qwerty;
        SceneManager.LoadScene(current_lvl);
    }

    public void currnetlvl(int asdf)
    {
        current_lvl = asdf;
    }

    public void restart()
    {
        SceneManager.LoadScene(current_lvl);
    }
}
