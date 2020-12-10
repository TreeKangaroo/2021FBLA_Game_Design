using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelLock : MonoBehaviour
{
    public Button[] Buttons;
    public int UnlockedCount;

    public void Update()
    {
        for (int i = 0; UnlockedCount > i; i++)
        {
            Buttons[i].interactable = true;
        }
    }
}
