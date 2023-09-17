using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBodyTracker : MonoBehaviour
{
    [SerializeField]
    private Rigidbody dragonBody;
    public Rigidbody DragonBody {get => dragonBody;}
    [SerializeField]
    private Transform dragonTransform;
    public Transform DragonTransform { get => dragonTransform; }
    [SerializeField]
    private GameObject playerObject;

    public void FacePlayer()
    {
        Vector3 targetLookPosition = new Vector3(playerObject.transform.position.x, dragonTransform.position.y, playerObject.transform.position.z);
        dragonTransform.LookAt(targetLookPosition);
    }

    public bool AtOrAboveVelocity(float velocityToCheck)
    {
        return dragonBody.velocity.magnitude > velocityToCheck;
    }

    public void AddForwardForce(float forceMultiplier)
    {

    }

    public void SetForwardVelocity(float velocityToSet)
    {
        dragonBody.velocity = dragonTransform.forward * velocityToSet;
    }
}
