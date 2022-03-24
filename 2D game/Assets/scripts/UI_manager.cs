//using Packages.Rider.Editor.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_manager : MonoBehaviour
{
    [SerializeField]
    private Text gameover_text;
    [SerializeField]
    private Text levelpass_text;
    [SerializeField]
    private Text restart_text;
    [SerializeField]
    private Text current_level_text;

    [SerializeField]
    private Text congo;
    [SerializeField]
    private Text game_comp;

    void Start()
    {
        gameover_text.gameObject.SetActive(false);
        levelpass_text.gameObject.SetActive(false);
        restart_text.gameObject.SetActive(false);
    }

    public void gameover()
    {
        gameover_text.gameObject.SetActive(true);
    }

    public void gamecompleted()
    {
        congo.gameObject.SetActive(true);
        game_comp.gameObject.SetActive(true);
    }

    public void restart()
    {
        restart_text.gameObject.SetActive(true);
    }

    public void current_level(int qwerty)
    {
        current_level_text.text = "LEVEL: " + qwerty;
        current_level_text.gameObject.SetActive(true);
    }
}
