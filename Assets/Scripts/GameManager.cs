using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    const int MAX_QUESTION_COUNT = 2;
    const int MAX_OPTIONS_COUNT = 4;

    [SerializeField] GameObject storyPanel;
    [SerializeField] GameObject resultPanel;
    [SerializeField] TextMeshProUGUI quesitonTxt;
    [SerializeField] TextMeshProUGUI[] optionsBtn = new TextMeshProUGUI[MAX_OPTIONS_COUNT];
    [SerializeField] TextMeshProUGUI correctCountTxt;
    [SerializeField] TextMeshProUGUI wrongCountTxt;
    ButtonManager bm;

    int correctCount, wrongCount;
    List<string> questions = new List<string>();
    List<string> option = new List<string>();
    List<List<string>> options = new List<List<string>>();
    List<int> correctOptions = new List<int>();

    int rndQuestion;

    void Start()
    {
        bm = GameObject.FindWithTag("ButtonManager").GetComponent<ButtonManager>();

        correctCount = 0;
        wrongCount = 0;

        questions.Add("Gerçek yetenek yarışmasında en fazla oy toplayan üç yarışmacı hangileridir?");
        questions.Add("Gerçek yetenek yarışmasında en az oy alan yarışmacı kimdir?");

        option.Add("Elif, Can ve Levent");
        option.Add("Mine, Elif ve Can");
        option.Add("Elif, Ramazan ve Can");
        option.Add("Mine, Ramazan ve Elif");

        option.Add("Levent");
        option.Add("Can");
        option.Add("Elif");
        option.Add("Ramazan");

        for (int i = 0; i < MAX_QUESTION_COUNT; i++)
        {
            List<string> copyList = new List<string>();
            for (int j = i * MAX_OPTIONS_COUNT; j < MAX_OPTIONS_COUNT + i * MAX_OPTIONS_COUNT; j++) copyList.Add(option[j]);
            options.Add(copyList);
        }

        correctOptions.Add(3);
        correctOptions.Add(1);

        rndQuestion = Random.Range(0, MAX_QUESTION_COUNT);

        StartCoroutine(DestroyStoryPanel());
        NextQuestion(rndQuestion);
    }

    public void NextQuestion(int questionNumber)
    {
        quesitonTxt.text = questions[questionNumber];

        for (int i = 0; i < MAX_OPTIONS_COUNT; i++) optionsBtn[i].text = options[questionNumber][i];
    }

    public void CheckAnswer(int answerNumber)
    {
        if (answerNumber == correctOptions[rndQuestion]) correctCount++;
        else wrongCount++;

        if (correctCount + wrongCount != MAX_QUESTION_COUNT)
        {
            questions.RemoveAt(rndQuestion);
            correctOptions.RemoveAt(rndQuestion);
            options.RemoveAt(rndQuestion);

            rndQuestion = Random.Range(0, MAX_QUESTION_COUNT - correctCount - wrongCount);
            NextQuestion(rndQuestion);
        }
        else
        {
            bm.DestroyCard();
            resultPanel.SetActive(true);
            correctCountTxt.text += correctCount.ToString();
            wrongCountTxt.text += wrongCount.ToString();
        }
    }

    IEnumerator DestroyStoryPanel()
    {
        yield return new WaitForSeconds(8f);
        Destroy(storyPanel);
        bm.GetCard(0);
    }
}