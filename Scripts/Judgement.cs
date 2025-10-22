using UnityEngine;

public class Judgement : MonoBehaviour {
    public AudioManager audio;
    public ScoreManager scoreManager;

    void Update() {
        if (Input.GetKeyDown(KeyCode.W)) CheckHit(new int[]{1,8});
        if (Input.GetKeyDown(KeyCode.A)) CheckHit(new int[]{6,7});
        if (Input.GetKeyDown(KeyCode.S)) CheckHit(new int[]{4,5});
        if (Input.GetKeyDown(KeyCode.D)) CheckHit(new int[]{2,3});

        if (Input.GetMouseButtonDown(0)) Debug.Log("Mouse Left Slide");
        if (Input.GetMouseButtonDown(1)) Debug.Log("Mouse Right Slide");
    }

    void CheckHit(int[] lanes) {
        float t = audio.GetSongTime();
        // TODO: 找出最近的 note，比對時間差
        float diff = 0.05f; // 假設差值
        if (diff <= 0.05f) scoreManager.AddScore("Perfect");
        else if (diff <= 0.1f) scoreManager.AddScore("Great");
        else if (diff <= 0.2f) scoreManager.AddScore("Good");
        else scoreManager.AddScore("Miss");
    }
}
