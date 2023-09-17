using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonStateController : MonoBehaviour
{
    [SerializeField]
    private MonoBehaviour startingState;
    private IDragonState currentState;
    // Start is called before the first frame update
    void Start()
    {
        currentState = (IDragonState)startingState;
        if (currentState == null)
        {
            currentState = GetComponent<IDragonState>();
        }
        currentState.EnterState();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState();
        if (currentState.NextState != currentState)
        {
            IDragonState newState = currentState.NextState;
            currentState.ExitState();
            newState.EnterState();
            currentState = newState;
        }
    }
}
