using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private HealthSystem healthSystem;
    private void Awake()
    {
        healthSystem = new HealthSystem(100);
        healthSystem.onDamageTaken += HealthSystem_onDamageTaken;
    }

    private void HealthSystem_onDamageTaken()
    {
        Debug.Log("Damage Taken");
    }

}
