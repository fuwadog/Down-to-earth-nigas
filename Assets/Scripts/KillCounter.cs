using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86.Avx;

public class KillCounter : MonoBehaviour
{
    public Text killCountText;
    private int killCount;

    void Start()
    {
        // Initialize kill count to 0 and update UI text
        killCount = 0;
        UpdateKillCountText();
    }

    public void IncrementKillCount()
    {
        // Increase kill count and update UI text
        killCount++;
        UpdateKillCountText();
    }

    void UpdateKillCountText()
    {
        // Update the UI text to display the current kill count
        killCountText.text = "Kills: " + killCount.ToString();
    }
}
