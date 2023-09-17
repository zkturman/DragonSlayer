using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDragonState
{
    public IDragonState NextState { get; }
    public void EnterState();
    public void UpdateState();
    public void ExitState();
}
