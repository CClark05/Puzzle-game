using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager i;
    public bool simulationRun = false;
    public static event Action onSimulationRestarted;
    public static event Action onSimulationRun;
    public static int currentLevel;
    public List<int> completedLevels;

    private void Awake()
    {

        Game_UI.onPlayButtonClicked += Game_UI_onPlayButtonClicked;
        Flag.onFlagEntered += Flag_onFlagEntered;
        DontDestroyOnLoad(this.gameObject);

        if(i == null)
        {
            i = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene(SceneHandler.GetSceneIndex(SceneHandler.Scenes.LevelSelect));
        }
    }
    private void Flag_onFlagEntered()
    {
        if (completedLevels.Count > 0)
        {
            for (var i = 0; i < completedLevels.Count; i++)
            {
                if (completedLevels[i] == currentLevel)
                {
                    return;
                }
            }
        }
        else
        {
            completedLevels.Add(currentLevel);
            return;
        }
        completedLevels.Add(currentLevel);
    }

    private void Game_UI_onPlayButtonClicked()
    {
        simulationRun = true;
        onSimulationRun?.Invoke();
    }


    public void RestartSimulation()
    {
        onSimulationRestarted?.Invoke();
    }
    public void RunSimulation()
    {
        onSimulationRun?.Invoke();
    }

    public void OnLevelWasLoaded(int level)
    {
        simulationRun = false;
    }
}


