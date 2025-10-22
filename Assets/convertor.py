import re, json

def time_for_unit(unit, bpm):
    sec_per_quarter = 60.0 / bpm
    return sec_per_quarter * 4.0 / unit

def parse_note_token(tok, current_unit, cursor_time, bpm):
    """解析單一 simai token -> 多個 note 物件"""
    notes = []
    # 多 lane 同時 (用 / 分隔)
    parts = tok.split("/")
    for part in parts:
        note = {"raw": part, "time": round(cursor_time, 3), "type": "tap"}
        # lane (1-8)
        m = re.search(r'([1-8])', part)
        if m:
            note["lane"] = int(m.group(1))
        # hold
        if "h[" in part:
            note["type"] = "hold"
            m2 = re.search(r'\[([0-9]+):([0-9]+)\]', part)
            if m2:
                div = int(m2.group(1))
                note["duration"] = round(time_for_unit(div, bpm), 3)
        # slide
        if "s" in part or "<" in part or ">" in part:
            note["type"] = "slide"
        notes.append(note)
    return notes

def simai_to_json(input_file, output_file):
    with open(input_file, "r", encoding="utf-8") as f:
        text = f.read()

    # 讀取 BPM (例如 (200))
    bpm_match = re.search(r'\((\d+)\)', text)
    bpm = float(bpm_match.group(1)) if bpm_match else 200.0

    tokens = re.findall(r'\{[0-9]+\}|[^\s,]+', text)
    current_unit = 4
    cursor_time = 0.0
    notes = []

    for tok in tokens:
        # subdivision {n}
        if tok.startswith("{") and tok.endswith("}"):
            current_unit = int(tok.strip("{}"))
            continue
        if tok.strip() == "":
            continue
        # parse note(s)
        parsed_notes = parse_note_token(tok, current_unit, cursor_time, bpm)
        for n in parsed_notes:
            if "lane" in n:
                notes.append(n)
        # 時間推進
        cursor_time += time_for_unit(current_unit, bpm)

    chart = {
        "title": input_file,
        "artist": "Unknown",
        "bpm": bpm,
        "notes": notes
    }

    with open(output_file, "w", encoding="utf-8") as out:
        json.dump(chart, out, indent=2, ensure_ascii=False)

    print(f"Converted {len(notes)} notes -> {output_file}")

if __name__ == "__main__":
    simai_to_json("ikazuchi.simai", "ikazuchi.json")
