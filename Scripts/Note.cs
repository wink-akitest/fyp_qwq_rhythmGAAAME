using UnityEngine;

public class Note : MonoBehaviour {
    public NoteData data;
    public float speed = 5f;

    public void Init(NoteData d) {
        data = d;
    }

    void Update() {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}
