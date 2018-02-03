using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class LitJsonUtils {
#region GameRecord
    public static GameRecord ParseGameRecord(string jsonString) {
        return ParseGameRecord(JsonMapper.ToObject(jsonString));
    }

    public static GameRecord ParseGameRecord(JsonData json) {
        GameRecord model = new GameRecord();
        model.score = json.OptInt32("score");
        model.star = json.OptInt32("star");
        return model;
    }

    public static string ToGameRecordString(GameRecord model) {
        JsonData json = new JsonData();
        json["score"] = model.score;
        json["star"] = model.star;
        return json.ToJson();
    }
    #endregion

#region User
    public static User ParseUser(string jsonString)
    {
        return ParseUser(JsonMapper.ToObject(jsonString));
    }

    public static User ParseUser(JsonData json)
    {
        User model = new User();
        model.sex = (Sex)json.OptInt32("sex");
        model.name = json.OptString("name");
        model.coin = json.OptInt32("coin");
        return model;
    }

    public static string ToUserString(User model)
    {
        JsonData json = new JsonData();
        json["sex"] = (int)model.sex;
        json["name"] = model.name;
        json["coin"] = model.coin;
        return json.ToJson();
    }
#endregion
}
