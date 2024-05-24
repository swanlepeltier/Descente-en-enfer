using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionDetection_hero : MonoBehaviour
{
    // Tag de l'objet avec lequel on veut détecter la collision
    public string targetTag;
    private float Hero_Health;

 void Start(){
        Hero_Health = (float)Variables.Object(this.gameObject).Get("Hero_Health");
    }

    // Fonction appelée lorsqu'une collision se produit
   
    void OnTriggerStay2D(Collider2D coll){          
        if (coll.gameObject.CompareTag(targetTag))
        {
            Hero_Health = (float)Variables.Object(this.gameObject).Get("Hero_Health") - (float)Variables.Object(coll.gameObject).Get("Damage");
            
            Variables.Object(this.gameObject).Set("Hero_Health",Hero_Health);
            Debug.Log(Variables.Object(this.gameObject).Get("Hero_Health"));
        }
    }
}