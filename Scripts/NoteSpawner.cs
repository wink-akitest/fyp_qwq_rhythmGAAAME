using UnityEngine;

public class NoteSpawner : MonoBehaviour {
    public GameObject notePrefab;
    public AudioManager audio;
    public ChartLoader loader;
    public float spawnAhead = 2f;

    private int index = 0;

    void Update() {
        if (index < loader.chart.notes.Count) {
            float noteTime = loader.chart.notes[index].time;
            if (audio.GetSongTime() >= noteTime - spawnAhead) {
                GameObject n = Instantiate(notePrefab, transform.position, Quaternion.identity);
                n.GetComponent<Note>().targetTime = noteTime;
                index++;
            }
        }
    }
}
