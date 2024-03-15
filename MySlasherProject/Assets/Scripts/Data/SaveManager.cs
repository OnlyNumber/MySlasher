using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveManager
{
    public static T Load<T>(string key) where T : new()
    {
        if (PlayerPrefs.HasKey(key))
        {

            return JsonUtility.FromJson<T>(PlayerPrefs.GetString(key));
        }

        return new T();
    }

    public static void Save<T>(T data,string dataName)
    {
        
        string save = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(dataName, save);
    }


}
