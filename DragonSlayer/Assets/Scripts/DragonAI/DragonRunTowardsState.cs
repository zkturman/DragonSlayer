using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonRunTowardsState : MonoBehaviour, IDragonState
{
    [SerializeField]
    private Animator animatorController;
    [SerializeField]
    private string animationTrigger = "Run";
    [SerializeField]
    private DragonStamina stamina;
    [SerializeField]
    private float staminaDrainPerSecon = 3f;
    [SerializeField]
    private DragonBodyTracker dragonBody;
    [SerializeField]
    private float runningSpeed;
    [SerializeField]
    private PlayerDistanceChecker playerDistanceChecker;
    [SerializeField]
    private float minimumAttackingDistance = 3f;

    public IDragonState NextState { get; private set; }

    public void EnterState()
    {
        NextState = this;
        animatorController.SetTrigger(animationTrigger);
        dragonBody.SetForwardVelocity(runningSpeed);
    }

    public void ExitState()
    {
        dragonBody.SetForwardVelocity(0f);
    }

    public void UpdateState()
    {
        stamina.ReduceStamina(staminaDrainPerSecon * Time.deltaTime);
        dragonBody.FacePlayer();
        if (playerDistanceChecker.DistanceToPlayer < minimumAttackingDistance)
        {
            NextState = GetComponent<DragonLightAttackState>();
        }
        if (Mathf.Approximately(stamina.GetStaminaPercentage(), 0f))
        {
            NextState = GetComponent<DragonScreamState>();
        }
    }
}
