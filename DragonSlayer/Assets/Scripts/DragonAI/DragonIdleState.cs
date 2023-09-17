using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonIdleState : MonoBehaviour, IDragonState
{
    [SerializeField]
    private Animator animatorController;
    [SerializeField]
    private string animationTrigger = "Idle";
    private float currentWaitedTimeInSeconds = 0f;
    private float waitingTimeInSeconds = 5f;
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
            NextState = GetComponent<DragonScreamState>();
        }
    }
}
