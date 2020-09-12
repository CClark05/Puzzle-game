using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager i;
    public bool simulationRun = false;
    private void Awake()
    {
        i = this;
        Game_UI.onPlayButtonClicked += Game_UI_onPlayButtonClicked;
    }

    private void Game_UI_onPlayButtonClicked()
    {
        simulationRun = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)){
            LevelLoader.i.ChangeScene(3, 2);
        }
    }


}
