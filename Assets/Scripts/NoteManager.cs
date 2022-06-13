using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    private List<Vector3> Pos = new List<Vector3> {
        new Vector3(11, -0.195f, -168),
        new Vector3(11, -0.195f, -160),
        new Vector3(11, 3.5f, -156),
        new Vector3(11, 3.5f, -153),
        new Vector3(11, 3.5f, -148),
        new Vector3(11, 3.5f, -144),
        new Vector3(11, -0.195f, -139),
        new Vector3(11, 3.5f, -135),
        new Vector3(11, 3.5f, -130),
        new Vector3(11, -0.195f, -125),
        new Vector3(11, 3.5f, -120),
        new Vector3(11, 3.5f, -115),
        new Vector3(11, -0.195f, -110),
        new Vector3(11, 3.5f, -105),
        new Vector3(11, 3.5f, -100),
        new Vector3(11, 3.5f, -96),
        new Vector3(11, -0.195f, -91),
        new Vector3(11, -0.195f, -85),
        new Vector3(11, -0.195f, -78),
        new Vector3(11, -0.195f, -74),
        new Vector3(-17.46f, 3.5f, -66.62f),
        new Vector3(-27, 3.5f, -66.62f),
        new Vector3(-37, -0.195f, -66.62f),
        new Vector3(-47.5f, 3.5f, -66.62f),
        new Vector3(-50, -0.195f, -66.62f),
        new Vector3(-60.9f, 3.5f, -66.62f),
        new Vector3(-70.5f, 3.5f, -66.62f),
        new Vector3(-81, -0.195f, -66.62f),
        new Vector3(-90.1f, -0.195f, -66.62f),
        new Vector3(-98.1f, 3.5f, -66.62f),

    };

    private List<int> notes = new List<int>{ 1,1,2,2,2,2,1,2,2,1,2,2,1,2,2,2,1,1,1,1,2,2,1,2,1,2,2,1,1,2 };

    private Queue<GameObject> noteQueue = new Queue<GameObject>();

    private GameObject note;

    private int noteMark = 0;

    void Start()
    {

        note = Resources.Load<GameObject>("Prefabs/Note/SA_Item_Fish");

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
