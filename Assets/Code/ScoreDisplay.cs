using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreDisplay : MonoBehaviour
{
    public Text TeamBlack;
    public Text TeamRed;
    public Text winnerText;

    public int teamBlackScore = 0;
    public int teamRedScore = 0;

    public static ScoreDisplay instance;

    private void Awake()
    {
        instance = this;
    }

    
}
