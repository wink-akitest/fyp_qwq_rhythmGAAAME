using UnityEngine;
using System.Collections.Generic;

public class Judgement : MonoBehaviour {
    public AudioManager audio;
    public ScoreManager scoreManager;

    private Dictionary<int, List<Note>> laneNotes = new Dictionary<int, List<Note>>();

    void Start() {
        for (int i = 0; i < 4; i++) {
            laneNotes[i] = new List<Note>();
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.A)) CheckHit(0);
        if (Input.GetKeyDown(KeyCode.S)) CheckHit(1);
        if (Input.GetKeyDown(KeyCode.D)) CheckHit(2);
        if (Input.GetKeyDown(KeyCode.F)) CheckHit(3);
    }

    void CheckHit(int lane) {
        if (laneNotes[lane].Count > 0) {
            Note note = laneNotes[lane][0];
            float diff = Mathf.Abs(audio.GetSongTime() - note.data.time);

            if (diff < 0.1f) {
                scoreManager.AddScore(300);
                Destroy(note.gameObject);
                laneNotes[lane].RemoveAt(0);
            } else if (diff < 0.2f) {
                scoreManager.AddScore(100);
                Destroy(note.gameObject);
                laneNotes[lane].RemoveAt(0);
            } else {
                Debug.Log("MISS (timing off)");
            }
        } else {
            Debug.Log("MISS (no note)");
        }
    }

    public void RegisterNote(Note note) {
        laneNotes[note.data.lane].Add(note);
    }
}
