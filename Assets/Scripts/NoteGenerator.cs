using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGenerator : MonoBehaviour {

    int Note = 0;
    public List<Vector3> NotePositions = new List<Vector3>();
    public List<GameObject> NoteColor = new List<GameObject>();

    // Use this for initialization
    void Start () {
        StartCoroutine(generator());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator generator() {
        while (true) { 
            yield return new WaitForSecondsRealtime(1f);
            Note = Random.Range(1, 5);
            generateNote(Note);
            Debug.Log(Note);
        }
    }

    void generateNote(int Color){
        GameObject newNote = Instantiate(NoteColor[Color - 1], NotePositions[Color - 1], Quaternion.identity);
    }
}
