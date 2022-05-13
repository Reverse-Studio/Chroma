using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class NoteManager : MonoBehaviour
{

    public GameObject note;
    float xPos;
    public int type;
    public float speed;

    void Awake()
    {
        speed = 10f;
        noteGenerator(note);
    }

    void FixedUpdate()
    {
       
    }

    public void noteGenerator(GameObject note)
    {
        Instantiate(note, new Vector3(6.4f, 0, 0), Quaternion.identity);
        type = 1;    
    }
}
