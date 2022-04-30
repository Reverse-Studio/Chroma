using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
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
       if (other.CompareTag("note"))
       {
            NoteGenerator.notes.RemoveAt(0);
            Destroy(other.gameObject);
       } 
    }
}
