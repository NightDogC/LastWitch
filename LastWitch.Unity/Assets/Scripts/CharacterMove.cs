using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    Vector3 target;
    Vector3 current;
    float dist;
    float speed = 6f;

    void Update()
    {
        if (dist > 1.3)
        {
            current = this.transform.position;
            transform.position = Vector3.MoveTowards(current, target, Time.deltaTime * speed);
            dist = Vector3.Distance(target, current);
        }
    }
    public void GoForSpot(SpotManager spot)
    {
        target = spot.transform.position;
        dist =  Vector3.Distance(target, current);
    }
}
