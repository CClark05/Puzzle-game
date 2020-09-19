using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager i;
    public bool simulationRun = false;
    public static event Action onSimulationRestarted;
    public static event Action onSimulationRun;
    private void Awake()
    {
        i = this;
        Game_UI.onPlayButtonClicked += Game_UI_onPlayButtonClicked;
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
}
