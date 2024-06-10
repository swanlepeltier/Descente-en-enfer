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
    public AudioSource src;
    public AudioClip Walking1, Walking2, Walking3;
    private int i;
    private float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Animator_Hero = GetComponent<Animator>();
    }

    void Update()
    {

        timer += Time.deltaTime;

        if (timer >= 0.4)
        {
            if (dir.magnitude > 0f){
                i = UnityEngine.Random.Range(1,4);

                if(i==1){src.clip = Walking1;}
                if(i==2){src.clip = Walking2;}
                if(i==3){src.clip = Walking3;}

                src.Play();
        }
            timer = 0.0f;
        }

        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        dir = dir.normalized;
        
        Animator_Hero.SetFloat("Speed",dir.magnitude);
        Animator_Hero.SetFloat("Horizontal", dir.x);
        Animator_Hero.SetFloat("Vertical", dir.y);


        rb.MovePosition(rb.position + dir * Speed * Time.fixedDeltaTime);
    }
}
