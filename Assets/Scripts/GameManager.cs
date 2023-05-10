using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    const int MAX_QUESTION_COUNT = 2;
     
    ButtonManager bm;

    int correctCount, wrongCount;
    List<string> questions = new List<string>();
    string[,] options = new string[MAX_QUESTION_COUNT, 5];
    List<int> correctOptions = new List<int>();

    int rndQuestion;

    void Start()
    {
        bm = GameObject.FindWithTag("ButtonManager").GetComponent<ButtonManager>();

        correctCount = 0;
        wrongCount = 0;

        questions.Add("Gerçek yetenek yarışmasında en fazla oy toplayan üç yarışmacı hangileridir?");
        questions.Add("Gerçek yetenek yarışmasında en az oy alan yarışmacı kimdir?");

        options[0, 0] = "Elif, Can ve Levent";
        options[0, 1] = "Mine, Elif ve Can";
        options[0, 2] = "Elif, Ramazan ve Can";
        options[0, 3] = "Mine, Ramazan ve Elif";
        options[0, 4] = "Can, Mine ve Ramazan";

        options[1, 0] = "Levent";
        options[1, 1] = "Can";
        options[1, 2] = "Elif";
        options[1, 3] = "Mine";
        options[1, 4] = "Ramazan";

        correctOptions.Add(3);
        correctOptions.Add(1);

        rndQuestion = Random.Range(0, 2);

        NextQuestion(rndQuestion);
    }

    public void NextQuestion(int questionNumber)
    {

    }

    public void CheckAnswer(int answerNumber)
    {
        if (answerNumber == correctOptions[rndQuestion]) correctCount++;
        else wrongCount++;
    }
}
