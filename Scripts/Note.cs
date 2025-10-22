using UnityEngine;

public class Note : MonoBehaviour {
    public NoteData data;
    public float speed = 5f;
    public float targetTime; // 音符應該被擊中的時間
    public int lane;         // 所屬的 lane (0=A,1=S,2=D,3=F)

    public void Init(NoteData d) {
        data = d;
        targetTime = d.time;
        lane = d.lane;
    }

    void Update() {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}
