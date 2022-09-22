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
            Error($"Enum({nameof(T)}) ���� {s}�� ����");
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
            Error($"{s} �� Int32 ������ �ٲܼ� ����");
            return -1;
        }

        return returnValue;
    }
    public static void RenameFile(string path, string oldFile, string newFile)
    {
        oldFile = path + "\\" + oldFile;
        newFile = path + "\\" + newFile;

        if (File.Exists(oldFile)) // ���� �ٲܷ��� ������ ������
        {
            File.Move(oldFile, newFile);
        }
        else
        {
            Error($"{oldFile} ������ ����");
        }
    }

    private static void Error(string errorString)
    {
        Debug.LogError($"Utility : {errorString}");
    }
}
