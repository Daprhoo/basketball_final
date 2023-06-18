using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    public GameObject ball;
    public Transform playersHand;

    public object scoreboard { get; internal set; }

    private void OnTriggerExit(Collider other) {

        ScoreDisplay.instance.teamBlackScore++;
        Debug.Log("team black " + ScoreDisplay.instance.teamBlackScore);
        ScoreDisplay.instance.TeamBlack.text = ScoreDisplay.instance.teamBlackScore.ToString();
        ball.transform.position = playersHand.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
