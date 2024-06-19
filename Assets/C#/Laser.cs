using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private GameObject targetObject;
    public int SweepSpeed = 10;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private float Attack_speed;
    private float Attack_speed_timer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        targetObject = GameObject.Find("Hero(Clone)");
        Attack_speed = UnityEngine.Random.Range(12f,16f);
    }

    void Update()
    {
        Attack_speed_timer += Time.deltaTime;
        if(Attack_speed_timer >= Attack_speed){
            Attack_speed_timer = 0f;
            Attack_speed = UnityEngine.Random.Range(12f,16f);
        }

        Vector2 targetPosition = targetObject.transform.position;
        Vector2 direction = targetPosition - rb.position;

        transform.up = direction;
        transform.Rotate(0,0,90);
    }
}
