using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonScreamState : MonoBehaviour, IDragonState
{
    [SerializeField]
    private Animator animatorController;
    [SerializeField]
    private string animationTrigger = "Scream";
    private float currentWaitedTimeInSeconds = 0f;
    [SerializeField]
    private float waitingTimeInSeconds = 2.8f;
    [SerializeField]
    private DragonStamina stamina;
    [SerializeField]
    private float staminaBurstAmount = 15f;
    [SerializeReference]
    private PlayerDistanceChecker distanceChecker;
    [SerializeReference]
    private float maximumCloseDistance = 10f;
    [SerializeReference]
    private float maximumMiddleDistance = 30f;
    [SerializeField]
    private AudioSource roarSource;
    [SerializeField]
    private AudioClip clipToPlay;

    public IDragonState NextState { get; private set; }

    public void EnterState()
    {
        NextState = this;
        currentWaitedTimeInSeconds = 0f;
        stamina.IncreateStamina(staminaBurstAmount);
        animatorController.SetTrigger(animationTrigger);
        
    }

    public void ExitState()
    {
    }

    public void UpdateState()
    {
        currentWaitedTimeInSeconds += Time.deltaTime;
        if (currentWaitedTimeInSeconds > waitingTimeInSeconds)
        {
            NextState = determineNextComponent();
        }
    }

    private IDragonState determineNextComponent()
    {
        IDragonState nextState;
        float distanceToPlayer = distanceChecker.DistanceToPlayer;
        if (distanceToPlayer < maximumCloseDistance)
        {
            nextState = GetComponent<DragonWalkTowardsState>();
        }
        else if (distanceToPlayer < maximumMiddleDistance)
        {
            nextState = GetComponent<DragonRunTowardsState>();
        }
        else
        {
            nextState = GetComponent<DragonWalkTowardsState>();
        }
        return nextState;
    }
}
