using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("destroy"))
       {
            GameObject.Find("Player").GetComponent<NOte>().notes.RemoveAt(0);
            Destroy(gameObject);
       } 
    }
}
