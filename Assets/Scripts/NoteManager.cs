using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    private List<Vector3> Pos = new List<Vector3> {
        new Vector3(11, -0.195f, -168),
        new Vector3(11, 2, -153), 
        new Vector3(11, 2, -148),
        new Vector3(11, -0.195f, -139), 
        new Vector3(11, 2, -135),
        new Vector3(11, 2, -130),
        new Vector3(11, -0.195f, -125),
        new Vector3(11, 2, -120),
        new Vector3(11, 2, -118),
        new Vector3(11, -0.195f, -117),
        new Vector3(11, 2, -115),
        new Vector3(11, 2, -110)
    };

    private List<int> notes = new List<int>{ 1, 2, 2, 1, 2, 2, 1, 2, 2, 1, 2, 2};

    private Queue<GameObject> noteQueue = new Queue<GameObject>();

    private GameObject note;

    private int noteMark = 0;

    void Start()
    {

        note = Resources.Load<GameObject>("Prefabs/Note/note");

    }       
    
    void Update()
    {
        while(noteQueue.Count >0 && noteQueue.Peek() == null)
        {
            noteQueue.Dequeue();
        }

        while (noteQueue.Count < 5 && noteMark < Pos.Count)
        {
            GameObject gen = Instantiate(note, Pos[noteMark], transform.rotation);
            Note noteCs = gen.AddComponent<Note>();
            noteCs.type = notes[noteMark];
            noteQueue.Enqueue(gen);
            noteMark += 1;  
        }
    }
}
