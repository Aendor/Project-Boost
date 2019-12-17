using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    Vector3 pos;
    
    [SerializeField] float speed = 10f;
    [SerializeField] float height = 10f;

    [SerializeField] float WaitTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        Invoke("MoveObstacle", WaitTime);
    }
    private void MoveObstacle()
    {
        float newY = pos.y + Mathf.Sin(Time.time * speed) * height;
        
        transform.position = new Vector3(pos.x, newY, pos.z);
    }
}
