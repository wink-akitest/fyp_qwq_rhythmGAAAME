# fyp_qwq_rhythmGAAAME

🎮 專案簡介
這是一個基於 Unity (C#) 開發的 敘事驅動音樂遊戲原型。
玩家透過節奏操作來「調查」小鎮的謎團，輸入的準確度會影響證據片段的完整度，進而影響 NPC 對話、謎題解答與故事分支。
目前這個 repo 展示的是 最小可行音遊框架：
- 音樂播放 (AudioManager)
- 譜面讀取 (JSON Chart Loader)
- Note 生成與掉落 (NoteSpawner)
- 判定系統 (HitDetector)

✨ 已完成功能
- [x] 音樂播放與時間同步
- [x] JSON 譜面讀取 (ikazuchi.json 範例)
- [x] Note 掉落與判定線
- [x] 基本判定 (Perfect / Great / Good / Miss)

🛠️ 使用方式
- 使用 Unity Hub 建立 2D 專案 (建議 Unity 2021 LTS 以上)。
- 將本 repo clone 下來：

git clone https://github.com/yourname/MindChasingPrototype.git

在 Unity 中打開專案。
在場景中放置：
- AudioManager (掛上 AudioSource，拖入音樂檔)
- ChartLoader (拖入 ikazuchi.json)
- NoteSpawner (連接 ChartLoader 與 Note Prefab)
- HitDetector (掛在判定線物件上)
按下 Play → 音樂播放 → note 掉落 → 按空白鍵判定。

📂 專案結構
Assets/
  Audio/        # 音樂檔
  Beatmaps/     # JSON 譜面
  Prefabs/      # Note 預製物件
  Scripts/      # C# 腳本 (AudioManager, NoteSpawner, HitDetector, ChartLoader)

📜 授權
本專案僅作為 畢業專題 (FYP) 原型，非商業用途。
