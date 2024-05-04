using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    // Tag de l'objet avec lequel on veut détecter la collision
    public string targetTag;

    // Fonction appelée lorsqu'une collision se produit
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Vérifier si la collision concerne l'objet avec le tag spécifié
        if (collision.gameObject.CompareTag(targetTag))
        {
            // Vérifier si le bouton de tir est enfoncé
            if (Input.GetButtonDown("Fire1"))
            {
                // Le code à exécuter lorsque la collision avec l'objet et que le bouton de tir est enfoncé
                // Par exemple, déclencher un événement, afficher un message, etc.
                Debug.Log("Collision avec l'objet " + targetTag + " détectée !");
            }
        }
    }
}

