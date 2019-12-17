using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    Vector3 pos;
    
    [SerializeField] float speed = 10f;
    [SerializeField] float height = 10f;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //calculate what the new Y position will be
        float newY = pos.y + Mathf.Sin(Time.time * speed) * height;
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(pos.x, newY, pos.z);
    }
}
