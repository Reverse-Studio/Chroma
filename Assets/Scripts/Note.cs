using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public int notespeed;
    private GameObject notes;
    
    // Start is called before the first frame update
    void Start()
    {
        notes = GameObject.Find("Note");
    }

    // Update is called once per frame
    void Update()
    {       
         notes.transform.position -= new Vector3(notespeed * Time.deltaTime, 0f, 0f);
    }

}
