using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    Vector3 target;
    Vector3 current;
    float dist;
    float speed = 6f;
    private void Awake()
    {
        current = this.gameObject.transform.position;
    }
    void Update()
    {
        if (dist > 1.3) // 可能会导致mask开启无法操作，界面无响应
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
