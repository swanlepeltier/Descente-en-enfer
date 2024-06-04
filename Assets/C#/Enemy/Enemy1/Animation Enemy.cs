using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Enemy1 : MonoBehaviour
{
    // Start is called before the first frame update
    Animator Animator_Enemy;
    Rigidbody2D rb;
    UnityEngine.Vector2 dir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Animator_Enemy = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dir = rb.velocity;
        Debug.Log(dir);
        Animator_Enemy.SetFloat("Speed_ennemy1",dir.magnitude);
        Animator_Enemy.SetFloat("Horizontal_ennemy1", dir.x);
        Animator_Enemy.SetFloat("Vertical_ennemy1", dir.y);
    }
}
