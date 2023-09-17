using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonStamina : MonoBehaviour
{
    [SerializeField]
    private float maxStamina = 50;
    [SerializeField]
    private float startStamina = 25;
    [SerializeReference]
    private float currentStamina; 
    private void Start()
    {
        currentStamina = startStamina;
    }

    public bool AtMaxStamina()
    {
        return Mathf.Approximately(currentStamina, maxStamina);
    }

    public bool CanUseStaminaAmount(float staminaCost)
    {
        return currentStamina >= staminaCost; 
    }

    public float GetStaminaPercentage()
    {
        return currentStamina / maxStamina;
    }

    public void IncreateStamina(float amountToIncrease)
    {
        currentStamina += amountToIncrease;
        if (currentStamina > maxStamina)
        {
            currentStamina = maxStamina;
        }
        else if (currentStamina < 0)
        {
            currentStamina = 0;
        }
    }

    public void ReduceStamina(float amountToReduce)
    {
        currentStamina -= amountToReduce;
        if (currentStamina < 0)
        {
            currentStamina = 0;
        }
        else if (currentStamina > maxStamina)
        {
            currentStamina = maxStamina;
        }
    }
}
