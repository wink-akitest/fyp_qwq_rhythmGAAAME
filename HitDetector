using UnityEngine;

public class HitDetector : MonoBehaviour {
    public AudioManager audio;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            double current = audio.GetSongTime();
            // 找最近的 note
            Note[] notes = FindObjectsOfType<Note>();
            Note closest = null;
            double minDiff = 999;

            foreach (Note n in notes) {
                double diff = Mathf.Abs((float)(n.targetTime - current));
                if (diff < minDiff) {
                    minDiff = diff;
                    closest = n;
                }
            }

            if (closest != null) {
                if (minDiff <= 0.03f) Debug.Log("Perfect!");
                else if (minDiff <= 0.07f) Debug.Log("Great!");
                else if (minDiff <= 0.13f) Debug.Log("Good!");
                else Debug.Log("Miss!");

                Destroy(closest.gameObject);
            }
        }
    }
}
