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
        StartCoroutine(MyCoroutine());
    }
    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(WaitTime);    //Wait
        //calculate what the new Y position will be
        float newY = pos.y + Mathf.Sin(Time.time * speed) * height;
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(pos.x, newY, pos.z);
    }
}
