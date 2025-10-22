using UnityEngine;

public class Judgement : MonoBehaviour {
    public AudioManager audio;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            float t = audio.GetSongTime();
            Debug.Log("Pressed at " + t);
            // 之後可以比對 note 的 targetTime，算 Perfect/Good/Miss
        }
    }
}
