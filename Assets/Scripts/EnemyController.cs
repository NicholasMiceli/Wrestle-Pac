using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform[] waypoints;
    int cur = 0;
    public float speed = 0.05f;
    void Start()
    {

    }


    void FixedUpdate()
    {
      if (transform.position != waypoints[cur].position) {
        Vector2 p = Vector2.MoveTowards(transform.position,
                                        waypoints[cur].position,
                                        speed);
        GetComponent<Rigidbody2D>().MovePosition(p);
    }
    else cur = (cur + 1) % waypoints.Length;

    }
}
