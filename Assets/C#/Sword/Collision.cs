using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class CollisionDetection : MonoBehaviour
{
    // Tag de l'objet avec lequel on veut détecter la collision
    public string targetTag;

    // Fonction appelée lorsqu'une collision se produit

    void OnTriggerStay2D(Collider2D coll){
    if (Input.GetButtonDown("Fire1"))
        {            
            if (coll.gameObject.CompareTag(targetTag))
            {
                Debug.Log("Collision avec l'objet " + targetTag + " détectée !");
                CustomEvent.Trigger(GameObject.Find("Hero(Clone)"),"Damage",coll.gameObject);
            }
        }
    }
}