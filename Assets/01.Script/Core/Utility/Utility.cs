using System;
using System.IO;
using UnityEngine;

public static class Utility
{
    public static T ParseStringToEnum<T>(string s)
    {
        T returnValue;

        try
        {
            returnValue = (T)Enum.Parse(typeof(T), s);
        }
        catch
        {
            Error($"Enum({nameof(T)}) 에는 {s}가 없음");
            return default(T);
        }

        return returnValue;
    }
    public static int ParseStringToInt(string s)
    {
        int returnValue;

        try
        {
            returnValue = Convert.ToInt32(s);
        }
        catch
        {
            Error($"{s} 를 Int32 형으로 바꿀수 없음");
            return -1;
        }

        return returnValue;
    }
    public static void RenameFile(string path, string oldFile, string newFile)
    {
        oldFile = path + "\\" + oldFile;
        newFile = path + "\\" + newFile;

        if (File.Exists(oldFile)) // 만약 바꿀려는 파일이 있으면
        {
            File.Move(oldFile, newFile);
        }
        else
        {
            Error($"{oldFile} 파일이 없음");
        }
    }

    private static void Error(string errorString)
    {
        Debug.LogError($"Utility : {errorString}");
    }
}
