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
    public IDragonState NextState { get; private set; }

    public void EnterState()
    {
        NextState = this;
        currentWaitedTimeInSeconds = 0f;
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
            NextState = GetComponent<DragonIdleState>();
        }
    }
}
