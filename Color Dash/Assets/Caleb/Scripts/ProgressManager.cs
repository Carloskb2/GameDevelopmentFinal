using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressManager : MonoBehaviour
{
    public Button[] levelButtons;

    // Start is called before the first frame update
    private void Start()
    {
        int highestLevelReached = PlayerPrefs.GetInt("HighestLevelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 <= highestLevelReached)
            {
                levelButtons[i].interactable = true;
            }
            else
            {
                levelButtons[i].interactable = false;
            }
        }
    }
}
