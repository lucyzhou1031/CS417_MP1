using UnityEngine;
using TMPro;

public class EscapeManager : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI progressText;
    public TextMeshProUGUI goldText;

    [Header("Escape")]
    public GameObject escapeWall;
    public int totalDoors = 3;

    private int unlockedDoors = 0;
    private int goldCount = 0;

    void Start()
    {
        UpdateUI();
        if (escapeWall != null) escapeWall.SetActive(true);
    }

    public void RegisterDoorUnlocked()
    {
        unlockedDoors++;
        if (unlockedDoors > totalDoors) unlockedDoors = totalDoors;

        UpdateUI();

        if (unlockedDoors >= totalDoors)
        {
            Escape();
        }
    }

    public void AddGold(int amount = 1)
    {
        goldCount += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (progressText != null)
            progressText.text = $"Doors Unlocked: {unlockedDoors}/{totalDoors}";

        if (goldText != null)
            goldText.text = $"Gold Collected: {goldCount}";
    }

    private void Escape()
    {
        if (escapeWall != null)
            escapeWall.SetActive(false);
    }
}
