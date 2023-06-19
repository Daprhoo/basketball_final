using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger1 : MonoBehaviour
{
    public GameObject ball;
    public Transform playersHand;
    public object scoreboard { get; internal set; }

     private void OnTriggerExit(Collider other) {


        ScoreDisplay.instance.teamRedScore++;
        Debug.Log("team red " + ScoreDisplay.instance.teamRedScore);
        ScoreDisplay.instance.TeamRed.text = ScoreDisplay.instance.teamRedScore.ToString();
        ball.transform.position = playersHand.position;
        //ScoreDisplay.instance.CheckWinner();
    }


}
