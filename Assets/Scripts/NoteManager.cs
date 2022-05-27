using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    List<Vector3> Pos = new List<Vector3> {
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
    List<int> notes = new List<int>{ 1, 2, 2, 1, 2, 2, 1, 2, 2, 1, 2, 2};
    GameObject note;
    public int noteMark = 0;

    void Start()
    {
        note = Resources.Load<GameObject>("Prefabs/Note/note");
        StartCoroutine(noteGenerator());
    }       
   
    IEnumerator noteGenerator()
    {
        foreach(Vector3 vector in Pos)
        {
            yield return new WaitForSeconds(0.5f);

                        

            GameObject gen =  Instantiate(note, vector, transform.rotation);
            Note noteCs = gen.AddComponent<Note>();
            noteCs.type = notes[noteMark];
            noteMark += 1;
        }
    }

    public void Destroy()
    {
        
    }
}
