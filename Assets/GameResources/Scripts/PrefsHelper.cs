using UnityEngine;

/// <summary>
/// Оболочка для PlayerPrefs
/// </summary>
public static class PrefsHelper
{
    /// <summary>
    /// Сохранить int
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public static void SetInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Сохранить float
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public static void SetFloat(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Сохранить string
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public static void SetString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Сохранить bool
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public static void SetBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key + BOOL_KEY, value ? 1 : 0);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Сохранить класс
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="obj"></param>
    public static void SetClass<T>(string key, T obj)
    {
        string json = JsonUtility.ToJson(obj);
        SetString(key, json);
    }

    /// <summary>
    /// Получить int
    /// </summary>
    /// <param name="key"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public static int GetInt(string key, int defaultValue = 0)
    {
        return PlayerPrefs.GetInt(key, defaultValue);
    }

    /// <summary>
    /// Получить float
    /// </summary>
    /// <param name="key"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public static float GetFloat(string key, float defaultValue = 0)
    {
        return PlayerPrefs.GetFloat(key, defaultValue);
    }

    /// <summary>
    /// Получить string
    /// </summary>
    /// <param name="key"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public static string GetString(string key, string defaultValue = default)
    {
        return PlayerPrefs.GetString(key, defaultValue);
    }

    /// <summary>
    /// Получить bool
    /// </summary>
    /// <param name="key"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public static bool GetBool(string key, bool defaultValue = false)
    {
        return PlayerPrefs.GetInt(key + BOOL_KEY, defaultValue ? 1 : 0) == 1 ? true : false;
    }

    /// <summary>
    /// Получить сериализованный объект
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="defaultObj"></param>
    /// <returns></returns>
    public static T GetClass<T>(string key, T defaultObj)
    {
        return HasKey(key) ? JsonUtility.FromJson<T>(GetString(key)) : defaultObj;
    }

    /// <summary>
    /// Проверить наличие ключа
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static bool HasKey(string key)
    {
        return PlayerPrefs.HasKey(key);
    }

    /// <summary>
    /// Удалить все префсы
    /// </summary>
    public static void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }

    /// <summary>
    /// Удалить ключ
    /// </summary>
    /// <param name="key"></param>
    public static void DeleteKey(string key)
    {
        PlayerPrefs.DeleteKey(key);
    }

    private static readonly string BOOL_KEY = "PrefsHelper.BOOL_KEY";
}
