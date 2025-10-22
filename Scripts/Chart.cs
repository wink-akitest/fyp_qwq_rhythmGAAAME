using System;
using System.Collections.Generic;

[Serializable]
public class NoteData {
    public float time;
    public string type; // "tap", "hold", "slide"
}

[Serializable]
public class Chart {
    public float bpm;
    public List<NoteData> notes;
}
