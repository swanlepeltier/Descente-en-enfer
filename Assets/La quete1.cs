using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class laQuete1 : MonoBehaviour
{
    public GameObject objectToFind;
    public GameObject quete;
    bool chestOK = false; // quete terminée ??
    public BoxCollider2D colliderPnj;
    string tagName = "SomeTag";
    

   
    // Start is called before the first frame update
    void Start()
    {
          
          objectToFind = GameObject.FindGameObjectWithTag(tagName);
          colliderPnj = objectToFind.GetComponent<BoxCollider2D>();
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     
   private void OnTriggerEnter2D(Collider2D collision)
   {
       if(collision.gameObject.name == "quete1")
       {
        Destroy(collision.gameObject.GetComponent<CircleCollider2D>());
        quete.SetActive(true);
        StartCoroutine("HideQuest");
       }
       if(collision.gameObject.name == "chest")
       {
        Destroy(collision.gameObject);
        chestOK = true; // quete fini
        Destroy(colliderPnj);
       }
   }

   IEnumerator HideQuest()
   {
    yield return new WaitForSeconds(5);
    quete.SetActive(false);
   }
   
}
