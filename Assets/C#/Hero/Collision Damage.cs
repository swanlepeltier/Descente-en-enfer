using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionDetection_hero : MonoBehaviour
{
    // Tag de l'objet avec lequel on veut détecter la collision
    public string targetTag;

    public string potion_tag = "Potion" ;
    private float Hero_Health;
    private float Hero_Shield;
    private float Damage_Enemy;
    private bool hero_invicible;

    public HealthBar healthBar;

 void Start(){
        Hero_Health = (float)Variables.Object(this.gameObject).Get("Hero_Health");
        Hero_Shield = (float)Variables.Object(this.gameObject).Get("Hero_Shield");
        healthBar.SetMaxHealth(Hero_Health);
    }

    // Fonction appelée lorsqu'une collision se produit
   
    void OnTriggerStay2D(Collider2D coll){          
        if (coll.gameObject.CompareTag(targetTag))
        {
            if (hero_invicible == false){
                Hero_Shield = (float)Variables.Object(this.gameObject).Get("Hero_Shield");
                Hero_Health = (float)Variables.Object(this.gameObject).Get("Hero_Health");
                Damage_Enemy = (float)Variables.Object(coll.gameObject).Get("Damage");
                if (Hero_Shield > 0){
                    Hero_Shield = Hero_Shield - Damage_Enemy;
                    if (Hero_Shield < 0){
                        Hero_Shield = 0f;
                    }
                    Variables.Object(this.gameObject).Set("Hero_Shield",Hero_Shield);
                    Debug.Log(Hero_Shield);
                }
                else {
                    Hero_Health = Hero_Health - Damage_Enemy;
                    healthBar.SetHealth(Hero_Health);
                    Variables.Object(this.gameObject).Set("Hero_Health",Hero_Health);
                }
                if (Hero_Health <= 0){
                    this.gameObject.SetActive(false);
                }
                else{
                    StartCoroutine(invincibility());
                }
            }
        }
    }
    IEnumerator invincibility(){
        float invincibility_time = 1f;
        hero_invicible = true;
        yield return new WaitForSeconds(invincibility_time);
        hero_invicible = false;
    }

    void OnTriggerEnter2D(Collider2D coll){
        if (coll.gameObject.CompareTag(potion_tag))
        {
            Hero_Health = (float)Variables.Object(this.gameObject).Get("Hero_Health") + (float)Variables.Object(coll.gameObject).Get("Health");
            if (Hero_Health > 100){
                   Hero_Health = 100f;  
                }
            Variables.Object(this.gameObject).Set("Hero_Health",Hero_Health);
            healthBar.SetHealth(Hero_Health);
            Debug.Log("Héro Heal");
            coll.gameObject.SetActive(false);
        }
    }
}