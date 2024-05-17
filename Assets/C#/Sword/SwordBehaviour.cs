using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEngine;

public class SwordBehaviour : MonoBehaviour
{
    public float SweepSpeed = 10f;

    private float Z_angle;
    Rigidbody2D rb;
    Vector2 MousePosition;
    private SpriteRenderer sprite;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        MousePosition = Input.mousePosition;
        MousePosition = Camera.main.ScreenToWorldPoint(MousePosition); // Position de la souris relative à la caméra

        Vector2 direction = new Vector2(
            MousePosition.x - transform.position.x,
            MousePosition.y - transform.position.y
        );
        transform.up = direction;

        Z_angle = transform.eulerAngles.z;
        
        if(Z_angle>270 || Z_angle<90){
            sprite.sortingOrder = -1;
        }
        else{
            sprite.sortingOrder = 1;
        }

        UnityEngine.Debug.Log(transform.eulerAngles.z);

        transform.Rotate (0,0,45);  // Parce que le sprite est orienté à -45° donc il faut compenser
    }
}
