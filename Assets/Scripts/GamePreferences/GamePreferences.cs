using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamePreferences
{
    public static string Easy = "Easy", Medium = "Medium", Hard = "Hard";
    public static string EasyScore = "EasyScore", MediumScore = "MediumScore", HardScore = "HardScore";
    public static string EasyCoins = "EasyCoins", MediumCoins = "MediumCoins", HardCoins = "HardCoins";

    public static string MusicOn = "MusicOn";

    public static void SetEasy(int difficulty)
    {
        PlayerPrefs.SetInt(Easy, difficulty);
    }

    public static int GetEasy()
    {
        return PlayerPrefs.GetInt(Easy);
    }

    public static void SetMedium(int difficulty)
    {
        PlayerPrefs.SetInt(Medium, difficulty);
    }

    public static int GetMedium()
    {
        return PlayerPrefs.GetInt(Medium);
    }

    public static void SetHard(int difficulty)
    {
        PlayerPrefs.SetInt(Hard, difficulty);
    }

    public static int GetHard()
    {
        return PlayerPrefs.GetInt(Hard);
    }

    public static void SetEasyScore(int difficulty)
    {
        PlayerPrefs.SetInt(EasyScore, difficulty);
    }

    public static int GetEasyScore()
    {
        return PlayerPrefs.GetInt(EasyScore);
    }

    public static void SetMediumScore(int difficulty)
    {
        PlayerPrefs.SetInt(MediumScore, difficulty);
    }

    public static int GetMediumScore()
    {
        return PlayerPrefs.GetInt(MediumScore);
    }

    public static void SetHardScore(int difficulty)
    {
        PlayerPrefs.SetInt(HardScore, difficulty);
    }

    public static int GetHardScore()
    {
        return PlayerPrefs.GetInt(HardScore);
    }


    public static void SetEasyCoins(int difficulty)
    {
        PlayerPrefs.SetInt(EasyCoins, difficulty);
    }

    public static int GetEasyCoins()
    {
        return PlayerPrefs.GetInt(EasyCoins);
    }

    public static void SetMediumCoins(int difficulty)
    {
        PlayerPrefs.SetInt(MediumCoins, difficulty);
    }

    public static int GetMediumCoins()
    {
        return PlayerPrefs.GetInt(MediumCoins);
    }

    public static void SetHardCoins(int difficulty)
    {
        PlayerPrefs.SetInt(HardCoins, difficulty);
    }

    public static int GetHardCoins()
    {
        return PlayerPrefs.GetInt(HardCoins);
    }



}

