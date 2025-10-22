using UnityEngine;

public class AudioManager : MonoBehaviour {
    public AudioSource music;
    private double startTime;

    void Start() {
        startTime = AudioSettings.dspTime;
        music.PlayScheduled(startTime);
    }

    public double GetSongTime() {
        return AudioSettings.dspTime - startTime;
    }
}
