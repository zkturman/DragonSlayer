using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDistanceChecker : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToTrack;
    [SerializeField]
    private DragonBodyTracker dragonBody;

    public float DistanceToPlayer { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        setDistance();
    }

    // Update is called once per frame
    void Update()
    {
        setDistance();
    }

    private void setDistance()
    {
        DistanceToPlayer = Vector3.Distance(objectToTrack.transform.position, dragonBody.DragonTransform.position);
    }
}
