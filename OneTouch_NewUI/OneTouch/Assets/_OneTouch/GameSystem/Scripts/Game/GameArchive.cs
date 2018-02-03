using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class GameArchive {

    #region User
    private static string key_user = "Key_User";
    private static User _user;
    public static User user { get { return _user ?? (_user = GetUser()); } }

    public static int musicOn;
    public static int soundOn;

    public static User GetUser()
    {
        if (_user == null)
        {
            string data = PlayerPrefs.GetString(key_user, "");
            if (string.IsNullOrEmpty(data))
                _user = new User();
            else
                _user = LitJsonUtils.ParseUser(data);
        }
        return _user;
    }

    public static void SaveUser() {
        PlayerPrefs.SetString(key_user, LitJsonUtils.ToUserString(GetUser()));
    }

    //声音存储
    public static void SaveG_Audio()     
    {
        PlayerPrefs.SetInt("musicOn",AudioManager.AudioManager.musicOn ? 1 : 0);
        PlayerPrefs.SetInt("soundOn", AudioManager.AudioManager.soundOn ? 1 : 0);
    }

    public static void CleanUser() {
        _user = new User();
        PlayerPrefs.SetString(key_user,"");

    }
    #endregion

    #region JumpRecord

    private static GameArchiveTemplate _jumpRecord;
    public static GameArchiveTemplate jumpRecord { get { return _jumpRecord ?? (_jumpRecord = new GameArchiveTemplate("JumpHighRecord")); } }
    //{
    //    get {
    //        if (_jumpRecord == null) {
    //            _jumpRecord = new GameArchiveTemplate("JumpHighRecord");
    //        }
    //        return _jumpRecord;
    //    }
    //}
    #endregion

    #region PushBallRecord
    private static GameArchiveTemplate _pushBallRecord;
    public static GameArchiveTemplate pushBallRecord { get { return _pushBallRecord ?? (_pushBallRecord = new GameArchiveTemplate("PushBallHighRecord")); } }

    #endregion
}


public class GameArchiveTemplate {
    
    private  string key = "HighRecord";
    private  GameRecord _record;

    private  bool isHighRecord;

    public GameArchiveTemplate(string key) {
        this.key = key;
        Debug.Log("GameArchiveTemplate.Key=" + key);
        isHighRecord = false;
    }

    /// <summary>
    /// 获取记录
    /// </summary>
    /// <returns></returns>
    public GameRecord GetRecord()
    {
        if (_record == null)
        {
            string data = PlayerPrefs.GetString(key, "");
            if (string.IsNullOrEmpty(data))
                _record = new GameRecord();
            else
                _record = LitJsonUtils.ParseGameRecord(data);
        }
        return _record;
    }
    /// <summary>
    /// 保存记录
    /// </summary>
    private void SaveRecord()
    {
        PlayerPrefs.SetString(key, LitJsonUtils.ToGameRecordString(GetRecord()));
    }

    public void CleanRecord() {
        if (_record != null) {
            _record.score = 0;
            _record.star = 0;
        }
        PlayerPrefs.SetString(key, "");
    }

    /// <summary>
    /// 设置分数
    /// </summary>
    /// <param name="score"></param>
    public void SetScore(int score)
    {
        if (GetRecord().score < score)
        {
            isHighRecord = true;//本次游戏产生了最高分；
            GetRecord().score = score;
            SaveRecord();
        }
    }
    /// <summary>
    /// 设置星星
    /// </summary>
    /// <param name="star"></param>
    public void SetStar(int star)
    {
        GetRecord().star = star;
        SaveRecord();
    }
    /// <summary>
    /// 累加星星数，最多加到5
    /// </summary>
    /// <param name="star"></param>
    /// <returns></returns>
    public bool AddStar(int star)
    {
        GetRecord().star += star;
        if (GetRecord().star > 5)
        {
            SetStar(5);
            return false;
        }
        else
        {
            SaveRecord();
            return true;
        }
    }
    /// <summary>
    /// 获取游戏最高分
    /// </summary>
    /// <returns></returns>
    public int GetHighScore()
    {
        return GetRecord().score;
    }
    /// <summary>
    /// 获取星星
    /// </summary>
    /// <returns></returns>
    public int GetStar()
    {
        return GetRecord().star;
    }

    public bool IsHighRecord()
    {
        return isHighRecord;
    }
}