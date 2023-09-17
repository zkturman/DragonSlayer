using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDragonState : MonoBehaviour, IDragonState
{
    public abstract IDragonState NextState { get; protected set; }

    public abstract void EnterState();

    public abstract void UpdateState();

    public abstract void ExitState();
}
