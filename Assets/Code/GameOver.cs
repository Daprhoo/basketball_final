using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text winnerText;
    // Start is called before the first frame update
    public void returnButton(){
    SceneManager.LoadScene(0);
    }

    void Start()
{
    string winningTeam = GetWinningTeam();

    if (winningTeam == "Berabere")
    {
        winnerText.text = "Tie"; // Beraberlik durumu
    }
    else
    {
        winnerText.text = "Winning Team : " + winningTeam; // Kazanan takımın adı
    }
}

    string GetWinningTeam()
    {
        if (ScoreDisplay.instance.teamBlackScore > ScoreDisplay.instance.teamRedScore)
        {
            return "Black Team"; // Siyah takım kazandı
        }
        else if (ScoreDisplay.instance.teamBlackScore < ScoreDisplay.instance.teamRedScore)
        {
            return "Red Team"; // Kırmızı takım kazandı
        }
        else
        {
            return "Berabere"; // Berabere
        }
    }
}
