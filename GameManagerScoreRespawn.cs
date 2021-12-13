using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScoreRespawn : MonoBehaviour
{

    public int currentQuestion;

    public Text questionTextScreenCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }


    //AddQuestion, adds Question count to the player
    public void AddQuestion(int QuestionToAdd)
    {
        currentQuestion = currentQuestion + QuestionToAdd;
        questionTextScreenCounter.text = "Selected Questions:" + currentQuestion;  //change text from the canvas renderer script
    }

}
