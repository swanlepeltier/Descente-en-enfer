using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SwordBehaviour : MonoBehaviour
{
    public float SweepSpeed = 10f;
    Rigidbody2D rb;
    Vector2 MousPos;
    float MousseAngle;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MousPos = Input.mousePosition;
        MousseAngle = MousPos.sqrMagnitude;
        rb.MoveRotation(MousseAngle * Time.fixedDeltaTime);

    }
}
