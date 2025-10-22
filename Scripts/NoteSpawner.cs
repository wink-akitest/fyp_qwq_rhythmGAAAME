using UnityEngine;

public class NoteSpawner : MonoBehaviour {
    public GameObject notePrefab;
    public AudioManager audio;
    public ChartLoader loader;
    public Judgement judgement;
    public float spawnAhead = 2f;
    public float songDelay = 2f;

    private int index = 0;

    void Start() {
        Invoke(nameof(StartSong), songDelay);
    }

    void StartSong() {
        audio.Play();
    }

    void Update() {
        if (index < loader.chart.notes.Count) {
            float noteTime = loader.chart.notes[index].time;
            if (audio.GetSongTime() >= noteTime - spawnAhead) {
                Vector3 pos = new Vector3(loader.chart.notes[index].lane - 1.5f, 5, 0);
                GameObject n = Instantiate(notePrefab, pos, Quaternion.identity);
                Note note = n.GetComponent<Note>();
                note.Init(loader.chart.notes[index]);
                judgement.RegisterNote(note);
                index++;
            }
        }
    }
}
