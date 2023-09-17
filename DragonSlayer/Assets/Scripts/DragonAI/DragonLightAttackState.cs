using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonLightAttackState : MonoBehaviour, IDragonState
{
    [SerializeField]
    private Animator animatorController;
    [SerializeField]
    private string animationTrigger = "LightAttack";
    [SerializeField]
    private DragonStamina stamina;
    [SerializeField]
    private float staminaCost;
    private float currentWaitedTimeInSeconds = 0f;
    private float waitingTimeInSeconds = 1.2f;
    public IDragonState NextState { get; private set; }

    public void EnterState()
    {
        NextState = this;
        currentWaitedTimeInSeconds = 0f;
        animatorController.SetTrigger(animationTrigger);
        stamina.ReduceStamina(staminaCost);
    }

    public void ExitState()
    {
    }

    public void UpdateState()
    {
        currentWaitedTimeInSeconds += Time.deltaTime;
        if (currentWaitedTimeInSeconds > waitingTimeInSeconds)
        {
            NextState = determineNextState();
        }
    }

    private IDragonState determineNextState()
    {
        IDragonState nextState;
        if (Mathf.Approximately(stamina.GetStaminaPercentage(), 0f))
        {
            nextState = GetComponent<DragonScreamState>();
        }
        else
        {
            nextState = GetComponent<DragonWalkTowardsState>();
        }
        return nextState;
    }
}
