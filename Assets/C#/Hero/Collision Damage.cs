using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CollisionDetection_hero : MonoBehaviour
{
    // Tag de l'objet avec lequel on veut détecter la collision
    public string targetTag;

    public string potion_tag = "Potion" ;
    private float Hero_Health;
    private float Hero_Shield;
    private float Hero_Shield_Max = 100f;
    private float Hero_Health_Max = 100f;
    private float Damage_Enemy;
    private bool hero_invicible;

    public HealthBar healthBar;
    public ShieldBar shieldBar;
    public AudioSource src;
    public AudioSource ShieldRegen;
    public AudioClip ShieldBreak, PotionDrink, GettingHit, ShieldRegenSound, ShieldFull;

    private float timeSinceLastCollision = 0f; 
    public float collisionCooldown = 5f;
    public float shieldRegenSpeed = 5f;
    private float timer;

    // Drapeau statique pour vérifier si PlayerPrefs a été réinitialisé
    private static bool prefsReset = false;

    void Awake()
    {
#if UNITY_EDITOR
        // Réinitialise PlayerPrefs lorsque le jeu démarre dans l'éditeur
        if (!prefsReset)
        {
            PlayerPrefs.DeleteAll();
            prefsReset = true;
        }
#endif
    }

 void Start(){
        healthBar = GameObject.Find("Health Bar").GetComponent<HealthBar>();
        shieldBar = GameObject.Find("Shield").GetComponent<ShieldBar>();

        // Vérifie si c'est le premier lancement
        if (PlayerPrefs.GetInt("FirstLaunch", 1) == 1)
        {
            Hero_Shield = (float)Variables.Object(this.gameObject).Get("Hero_Shield");
            Hero_Health = (float)Variables.Object(this.gameObject).Get("Hero_Health");
            // Initialiser les valeurs par défaut
            Hero_Health = 100f; // Valeur par défaut pour la santé
            Hero_Shield = Hero_Shield_Max; // Valeur par défaut pour le bouclier

            // Marque le jeu comme déjà lancé
            PlayerPrefs.SetInt("FirstLaunch", 0);
        }
        else{
            Hero_Health = PlayerPrefs.GetFloat("Hero_Health");
            PlayerPrefs.DeleteKey("Hero_Health");
            Hero_Shield = PlayerPrefs.GetFloat("Hero_Shield");
            PlayerPrefs.DeleteKey("Hero_Shield");
        }

        healthBar.SetMaxHealth(Hero_Health_Max);
        shieldBar.SetMaxHealth(Hero_Shield_Max);
        healthBar.SetHealth(Hero_Health);
        shieldBar.SetHealth(Hero_Shield);

        ShieldRegen.clip = ShieldRegenSound;
        ShieldRegen.volume = 0.05f;
    }

void Update(){
    timeSinceLastCollision += Time.deltaTime;

    if(timeSinceLastCollision >= collisionCooldown && Hero_Shield < Hero_Shield_Max){
        if(Hero_Shield+1>=Hero_Shield_Max){
            Hero_Shield = Hero_Shield_Max;
        }
        else{
        Hero_Shield += shieldRegenSpeed * Time.deltaTime;

        timer += Time.deltaTime;

        if (timer >= 0.15f)
        {
            ShieldRegen.clip = ShieldRegenSound;
            ShieldRegen.Play();
            timer = 0.0f;
        }
        }
        if(Hero_Shield >= Hero_Shield_Max){
            ShieldRegen.clip = ShieldFull;
            ShieldRegen.Play();
        }
        shieldBar.SetHealth(Hero_Shield);
    }
}

    // Fonction appelée lorsqu'une collision se produit
   
    void OnTriggerStay2D(Collider2D coll){      
        if (coll.gameObject.CompareTag(targetTag))
        {
            timeSinceLastCollision = 0f;
            if (hero_invicible == false){
                src.clip = GettingHit;
                src.Play();
                Damage_Enemy = (float)Variables.Object(coll.gameObject).Get("Damage");
                if (Hero_Shield > 0){
                    Hero_Shield = Hero_Shield - Damage_Enemy;
                    if (Hero_Shield < 0){
                        Hero_Shield = 0f;
                        src.clip = ShieldBreak;
                        src.Play();
                    }
                    Variables.Object(this.gameObject).Set("Hero_Shield",Hero_Shield);
                    shieldBar.SetHealth(Hero_Shield);
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
            src.clip = PotionDrink;
            src.Play();
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
    void OnDestroy()
    {
        PlayerPrefs.SetFloat("Hero_Health", Hero_Health);
        PlayerPrefs.SetFloat("Hero_Shield", Hero_Shield);
        PlayerPrefs.Save();
    }

    private void OnApplicationQuit()
    {
        // Réinitialiser les valeurs à la fermeture de l'application
        PlayerPrefs.DeleteAll();
    }
}