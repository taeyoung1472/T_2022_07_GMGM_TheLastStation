using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;
using System;

public class EditorSceneHandler : MonoBehaviour
{
    #region Public
    [MenuItem("Taeyoung/Scene/Public/Game-Train")]
    public static void LoadGame_Train()
    {
        EditorSceneManager.OpenScene("Assets/00.Scenes/Main/Game-Train.unity");
    }
    [MenuItem("Taeyoung/Scene/Public/Game-Station")]
    public static void LoadGame_Station()
    {
        EditorSceneManager.OpenScene("Assets/00.Scenes/Main/Game-Station.unity");
    }
    [MenuItem("Taeyoung/Scene/Public/Menu")]
    public static void LoadMenu()
    {
        EditorSceneManager.OpenScene("Assets/00.Scenes/Main/Menu.unity");
    }
    #endregion

    #region Dev
    [MenuItem("Taeyoung/Scene/Dev/NaEun")]
    public static void LoadNaEun()
    {
        EditorSceneManager.OpenScene("Assets/00.Scenes/Dev/NaEun/NaEun.unity");
    }
    [MenuItem("Taeyoung/Scene/Dev/HyunWoong")]
    public static void LoadHyunWoong()
    {
        EditorSceneManager.OpenScene("Assets/00.Scenes/Dev/HyunWoong/HyunWoong.unity");
    }
    [MenuItem("Taeyoung/Scene/Dev/JunSeong")]
    public static void LoadJunSeong()
    {
        EditorSceneManager.OpenScene("Assets/00.Scenes/Dev/JunSeong/JunSeong.unity");
    }
    [MenuItem("Taeyoung/Scene/Dev/SeolAh")]
    public static void LoadSeolAh()
    {
        EditorSceneManager.OpenScene("Assets/00.Scenes/Dev/SeolAh/SeolAh.unity");
    }
    #endregion
}
