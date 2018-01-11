using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class GameArchive {

#region JumpRecord
    private const string Key_jumpHighRecord = "JumpHighRecord";
    private static GameRecord _jumpRecord;

    private static bool isHighRecord;

    /// <summary>
    /// 获取跳绳记录
    /// </summary>
    /// <returns></returns>
    public static GameRecord GetJumpRecord() {
        if (_jumpRecord == null) {
            string data = PlayerPrefs.GetString(Key_jumpHighRecord, "");
            if (string.IsNullOrEmpty(data))
                _jumpRecord = new GameRecord();
            else
                _jumpRecord = LitJsonUtils.ParseGameRecord(data);
        }
        return _jumpRecord;
    }
    /// <summary>
    /// 保存跳绳记录
    /// </summary>
    private static void SaveJumpRecord()
    {
        PlayerPrefs.SetString(Key_jumpHighRecord, LitJsonUtils.ToGameRecordString(GetJumpRecord()));
    }
    /// <summary>
    /// 设置跳绳分数
    /// </summary>
    /// <param name="score"></param>
    public static void SetJumpScore(int score) {
        if (GetJumpRecord().score < score)
        {
            isHighRecord = true;//本次游戏产生了最高分；
            GetJumpRecord().score = score;
            SaveJumpRecord();
        }
    }
    /// <summary>
    /// 设置跳绳星星
    /// </summary>
    /// <param name="star"></param>
    public static void SetJumpStar(int star) {
        GetJumpRecord().star = star;
        SaveJumpRecord();
    }
    /// <summary>
    /// 累加星星数，最多加到5
    /// </summary>
    /// <param name="star"></param>
    /// <returns></returns>
    public static bool AddJumpStar(int star) {
        GetJumpRecord().star += star;
        if (GetJumpRecord().star > 5)
        {
            SetJumpStar(5);
            return false;
        }
        else {
            SaveJumpRecord();
            return true;
        }
    }
    /// <summary>
    /// 获取跳绳游戏最高分
    /// </summary>
    /// <returns></returns>
    public static int GetJumpHighScore() {
        return GetJumpRecord().score;
    }
    /// <summary>
    /// 获取跳绳星星
    /// </summary>
    /// <returns></returns>
    public static int GetJumpStar() {
        return GetJumpRecord().star;
    }

    public static bool IsHighRecord()
    {
        if (isHighRecord) return true;
        else
        {
            return false;
        }
    }
    #endregion

}
