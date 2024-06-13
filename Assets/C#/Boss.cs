using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private GameObject targetObject;
    private float Health;
    public float Speed;
    public HealthBar healthBar;
    private Rigidbody2D rb;
    private Animator anim;
    private float Attack_speed;
    private float Attack_speed_timer;

    void Start()
    {
        Health = (float)Variables.Object(this).Get("Health");
        healthBar = GameObject.Find("Boss Bar").GetComponent<HealthBar>();
        healthBar.SetMaxHealth(Health);
        healthBar.SetHealth(Health);

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        targetObject = GameObject.Find("Hero(Clone)");

        Attack_speed=Random.Range(8f,12f);
    }
    void Update()
    {
        Attack_speed_timer += Time.deltaTime;
        if(Attack_speed_timer >= Attack_speed){
            anim.Play("Boss_Melee");
            Attack_speed_timer = 0f;
            Attack_speed=Random.Range(8f,12f);
            
        }
        Health = (float)Variables.Object(this).Get("Health");
        healthBar.SetHealth(Health);

        Vector2 targetPosition = targetObject.transform.position;
        Vector2 direction = targetPosition - rb.position;
        direction.Normalize();
 
        rb.MovePosition(rb.position + direction * Speed * Time.deltaTime);
        
    }
}
