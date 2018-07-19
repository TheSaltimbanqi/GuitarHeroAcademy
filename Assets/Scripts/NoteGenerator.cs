using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGenerator : MonoBehaviour {

    int Note = 0;
    public List<GameObject> NoteColor = new List<GameObject>();
    public List<GameObject> NoteTargets = new List<GameObject>();

    public Transform parent;
    
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
        GameObject newNote = Instantiate(NoteColor[Color - 1], NoteColor[Color - 1].transform.position, Quaternion.identity) as GameObject;
        newNote.transform.SetParent(parent);
        StartCoroutine(MoveToPosition(newNote.transform, NoteTargets[Color - 1].transform.position, 6f));
    }

    //float t;
    //Vector3 startPos;
    //Vector3 targetPos;
    //float timeMove;
    /*
    public void SetDestination(Vector3 destination, float time)
    {
        t = 0;
        startPos = transform.position;
        timeMove = time;
        targetPos = destination;
    }
    */

    public IEnumerator MoveToPosition(Transform transform, Vector3 position, float timeToMove)
    {
        var currentPos = transform.position;
        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            transform.position = Vector3.Lerp(currentPos, position, t);
            yield return null;
        }
    }
}
