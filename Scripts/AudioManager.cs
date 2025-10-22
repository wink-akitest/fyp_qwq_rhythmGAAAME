using UnityEngine;

public class AudioManager : MonoBehaviour {
    public AudioSource music;

    public void Play() {
        music.Play();
    }

    public float GetSongTime() {
        return music.time;
    }
}
