using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameEndText;

    void Update()
    {
        if (GameManager.Instance.isWon)
        {
            gameEndText.text = "Congratulations, you have won the game! Press R to restart or ESC to exit";
        }
        else if (GameManager.Instance.isLost)
        {
            gameEndText.text = "You died, press R to restart";
        }
        else
        {
            gameEndText.text = " ";
        }
    }
}
