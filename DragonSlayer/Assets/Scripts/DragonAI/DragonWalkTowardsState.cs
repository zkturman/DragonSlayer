using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonWalkTowardsState : MonoBehaviour, IDragonState
{
    [SerializeField]
    private Animator animatorController;
    [SerializeField]
    private string animationTrigger = "Walk";
    [SerializeField]
    private PlayerDistanceChecker distanceChecker;
    [SerializeField]
    private DragonBodyTracker dragonBody;
    [SerializeField]
    private float walkingSpeed = 20f;
    [SerializeField]
    private float minimimumAttackDistance = 5f;
    [SerializeField]
    private float minimumRunningDistance = 15f;
    [SerializeField]
    private DragonStamina stamina;
    [SerializeField]
    private float staminaIncreasePerSecond = 1f;
    [SerializeField]
    private float minimumRunStamina = 25f;

    private float currentWaitedTimeInSeconds = 0f;
    private float waitingTimeInSeconds = 5f;
    public IDragonState NextState { get; private set; }

    public void EnterState()
    {
        NextState = this;
        currentWaitedTimeInSeconds = 0f;
        animatorController.SetTrigger(animationTrigger);
        dragonBody.FacePlayer();
        dragonBody.SetForwardVelocity(walkingSpeed);
    }

    public void ExitState()
    {
        dragonBody.SetForwardVelocity(0);
    }

    public void UpdateState()
    {
        dragonBody.FacePlayer();
        dragonBody.SetForwardVelocity(walkingSpeed);
        stamina.IncreateStamina(staminaIncreasePerSecond * Time.deltaTime);
        if (distanceChecker.DistanceToPlayer < minimimumAttackDistance)
        {
            NextState = GetComponent<DragonLightAttackState>();
        }
        else if (distanceChecker.DistanceToPlayer > minimumRunningDistance && stamina.CanUseStaminaAmount(minimumRunStamina))
        {
            NextState = GetComponent<DragonRunTowardsState>();
        }
    }

}
