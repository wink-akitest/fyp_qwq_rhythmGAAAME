using System;
using System.Collections.Generic;

[Serializable]
public class NoteData {
    public float time;
    public int lane;   // 0=A, 1=S, 2=D, 3=F
    public string type; // "tap", "hold", "slide"
}

[Serializable]
public class Chart {
    public float bpm;
    public List<NoteData> notes;
}
