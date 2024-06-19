using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Findreference : MonoBehaviour
{
    public GameObject objectToFind;
    public BoxCollider2D boxCollider2D;
    string tagName = "SomeTag";
    // Start is called before the first frame update
    void Start()
    {
        objectToFind = GameObject.FindGameObjectWithTag(tagName);
       boxCollider2D = objectToFind.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
