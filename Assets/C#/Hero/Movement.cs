using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed = 5f;
    Animator Animator_Hero;
    Rigidbody2D rb;
    UnityEngine.Vector2 dir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Animator_Hero = GetComponent<Animator>();
    }

    void Update()
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        dir = dir.normalized;
        
        Animator_Hero.SetFloat("Speed",dir.magnitude);
        Animator_Hero.SetFloat("Horizontal", dir.x);
        Animator_Hero.SetFloat("Vertical", dir.y);


        rb.MovePosition(rb.position + dir * Speed * Time.fixedDeltaTime);
    }
}
