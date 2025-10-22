using UnityEngine;

[System.Serializable]
public class NoteData {
    public float time;
    public int lane;
    public string type;
    public float duration;
}

[System.Serializable]
public class Chart {
    public string title;
    public string artist;
    public float bpm;
    public NoteData[] notes;
}

public class ChartLoader : MonoBehaviour {
    public TextAsset chartFile;
    public Chart chart;

    void Awake() {
        chart = JsonUtility.FromJson<Chart>(chartFile.text);
    }
}
