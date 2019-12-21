using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Ocillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector;

    // todo: Remove from inspector later
    [Range(0,1)] [SerializeField] float movementFactor; // 0 for not moved 1 for fully moved

    Vector3 startingPos;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = movementVector * movementFactor;
        this.transform.position = startingPos + offset;
    }
}
