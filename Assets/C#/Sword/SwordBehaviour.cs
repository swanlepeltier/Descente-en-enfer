using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SwordBehaviour : MonoBehaviour
{
    public float SweepSpeed = 10f;
    Rigidbody2D rb;
    Vector2 MousePosition;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

        transform.Rotate (0,0,45);  // Parce que le sprite est orienté à -45° donc il faut compenser
    }
}
