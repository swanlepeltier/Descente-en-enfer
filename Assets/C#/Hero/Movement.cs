using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed = 5f;
    public Animation anim;
    Rigidbody2D rb;
    UnityEngine.Vector2 dir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animation>();
        foreach (AnimationState state in anim)
        {
            state.speed = 0.5F;
        }
    }

    void Update()
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        dir = dir.normalized;
        rb.MovePosition(rb.position + dir * Speed * Time.fixedDeltaTime);
    }
}
