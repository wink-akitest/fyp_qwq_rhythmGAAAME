using UnityEngine;

public class Note : MonoBehaviour {
    public float targetTime;
    public int lane;
    public string type;
    public float duration;

    private float speed = 5f;

    public void Init(NoteData data) {
        targetTime = data.time;
        lane = data.lane;
        type = data.type;
        duration = data.duration;
    }

    void Update() {
        transform.position += Vector3.down * speed * Time.deltaTime;
        if (transform.position.y < -5) Destroy(gameObject);
    }
}
