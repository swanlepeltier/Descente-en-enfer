using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quete2 : MonoBehaviour
{
    public GameObject objectToFind;
    public GameObject quete3;
    bool KeyOK = false; // quete terminée ??
    public BoxCollider2D colliderPorte;
    string tagName = "SomeTag";
    
    // Start is called before the first frame update
    void Start()
    {
         objectToFind = GameObject.FindGameObjectWithTag(tagName);
          colliderPorte = objectToFind.GetComponent<BoxCollider2D>();
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
private void OnTriggerEnter2D(Collider2D collision)
   {
       if(collision.gameObject.name == "npc")
       {
        Destroy(collision.gameObject.GetComponent<CircleCollider2D>());
        quete3.SetActive(true);
        StartCoroutine("HideQuest");
       }
       if(collision.gameObject.name == "Key")
       {
        Destroy(collision.gameObject);
        KeyOK = true; // quete fini
        Destroy(colliderPorte);
       }
   }

   IEnumerator HideQuest()
   {
    yield return new WaitForSeconds(5);
    quete3.SetActive(false);
   }
   
}
