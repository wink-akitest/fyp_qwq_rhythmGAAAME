using UnityEngine;

public class NoteSpawner : MonoBehaviour {
    public GameObject notePrefab;
    public AudioManager audio;
    public ChartLoader loader;
    public float spawnAhead = 2f;

    private int index = 0;

    void Update() {
        if (index < loader.chart.notes.Length) {
            float noteTime = loader.chart.notes[index].time;
            if (audio.GetSongTime() >= noteTime - spawnAhead) {
                Vector3 pos = new Vector3(loader.chart.notes[index].lane - 4.5f, 5, 0);
                GameObject n = Instantiate(notePrefab, pos, Quaternion.identity);
                n.GetComponent<Note>().Init(loader.chart.notes[index]);
                index++;
            }
        }
    }
}
