[System.Serializable]
public class NoteData {
    public float time;       // 出現時間 (秒)
    public int lane;         // 1–8
    public string type;      // "tap", "hold", "slide"
    public float duration;   // hold 長度 (可選)
    public string direction; // slide 方向 (可選)
}

[System.Serializable]
public class Chart {
    public string title;
    public string artist;
    public float bpm;
    public NoteData[] notes;
}
