using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveManager
{
    public static T Load<T>(string dataName) where T :  new()
    {

        if(PlayerPrefs.HasKey(dataName))
        {
            return JsonUtility.FromJson<T>(PlayerPrefs.GetString(dataName));
        }

        return new T();
    }

    public static void Save<T>(T data,string dataName)
    {
        string save = JsonUtility.ToJson(data);

        PlayerPrefs.SetString(dataName, save);
    }


}
