import re, json

BPM = 200.0
SECONDS_PER_QUARTER = 60.0 / BPM

def time_for_unit(unit):
    return SECONDS_PER_QUARTER * 4.0 / unit

def parse_note(tok, current_unit, cursor_time):
    note = {"raw": tok, "time": round(cursor_time, 3), "type": "tap"}
    m = re.search(r'([1-8])', tok)
    if m:
        note["lane"] = int(m.group(1))
    if "h[" in tok:
        note["type"] = "hold"
        m2 = re.search(r'\[([0-9]+):([0-9]+)\]', tok)
        if m2:
            div = int(m2.group(1))
            note["duration"] = round(time_for_unit(div), 3)
    if "s" in tok:
        note["type"] = "slide"
    return note

def main():
    with open("ikazuchi.simai", "r", encoding="utf-8") as f: #the simai file name need to change
        text = f.read()
    tokens = re.findall(r'\{[0-9]+\}|[^\s,]+', text)
    current_unit = 8
    cursor_time = 0.0
    notes = []
    for tok in tokens:
        if tok.startswith("{") and tok.endswith("}"):
            current_unit = int(tok.strip("{}"))
            continue
        if tok.strip() == "":
            continue
        note = parse_note(tok, current_unit, cursor_time)
        if "lane" in note:
            notes.append(note)
        cursor_time += time_for_unit(current_unit)
    chart = {"title": "Ikazuchi", "artist": "光吉猛修", "bpm": BPM, "notes": notes} f: #the song name need to change
    with open("ikazuchi.json", "w", encoding="utf-8") as out:
        json.dump(chart, out, indent=2, ensure_ascii=False)
    print(f"Converted {len(notes)} notes -> ikazuchi.json")

if __name__ == "__main__":
    main()
