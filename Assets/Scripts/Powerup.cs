using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : ScriptableObject
{
    public bool isActive;
    [SerializeField]
    protected int[] UpgradeCosts;
    [SerializeField]
    protected int currentLevel = 1;
    [SerializeField]
    protected int maxLevel = 3;
    [SerializeField]
    protected PowerupStats duration;
    public float GetDuration() { return duration.GetValue(currentLevel); }
    private void Awake()
    {
        LoadPowerupLevel();
    }
    private void OnValidate()
    {
        currentLevel = Mathf.Min(currentLevel, maxLevel);
        currentLevel = Mathf.Max(currentLevel, 1);
    }
    public bool IsMaxedOut()
    {
        return currentLevel == maxLevel;
    }
    public int GetNextUpgradeCost()
    {
        if (!IsMaxedOut())
        {
            return UpgradeCosts[currentLevel - 1];
        }
        else
        {
            return -1;
        }
    }
    public void Upgrade()
    {
        if (IsMaxedOut()) return;
        // -----------------------
        currentLevel++;
        SavePowerupLevel();
    }
    // potrzeba zapisaæ oraz wczytaæ do/z PlayerPrefs poziom powerupa, aby po zbudowaniu by³ zapamiêtywany obecny poziom powerupa
    private void SavePowerupLevel()
    {
        string key = name + "Level";
        PlayerPrefs.SetInt(key, currentLevel);
    }
    private void LoadPowerupLevel()
    {
        string key = name + "Level";
        if (PlayerPrefs.HasKey(key))
        {
            currentLevel = PlayerPrefs.GetInt(key);
        }
    }
    public override string ToString()
    {
        string text = $"{name}\nLVL. {currentLevel}";
        if (IsMaxedOut())
            text += " (MAX)";
        return text;
    }
    public string UpgradeCostString()
    {
        if (!IsMaxedOut())
            return $"UPGRADE\nCOST: {GetNextUpgradeCost()}";
        else
            return "MAXED OUT";
    }
}