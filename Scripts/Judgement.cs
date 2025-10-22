using UnityEngine;

public class Judgement : MonoBehaviour {
    public AudioManager audio;

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
        Debug.Log("Pressed at " + t + " for lanes " + string.Join(",", lanes));
        // TODO: 比對 note.targetTime，計算 Perfect/Great/Good/Miss
    }
}
