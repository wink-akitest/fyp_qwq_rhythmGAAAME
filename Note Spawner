using UnityEngine;
using System.Collections.Generic;

public class NoteSpawner : MonoBehaviour {
    public GameObject notePrefab;
    public AudioManager audio;
    public float spawnAhead = 2f; // 提前生成時間

    private List<float> notes = new List<float>{1f, 2f, 3f, 4f}; // 測試用譜面
    private int index = 0;

    void Update() {
        if (index < notes.Count && audio.GetSongTime() >= notes[index] - spawnAhead) {
            GameObject n = Instantiate(notePrefab, transform.position, Quaternion.identity);
            n.GetComponent<Note>().targetTime = notes[index];
            index++;
        }
    }
}
