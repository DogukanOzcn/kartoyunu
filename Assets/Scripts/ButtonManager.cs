using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Animations;

public class ButtonManager : MonoBehaviour
{
    const int CARD_COUNT = 5;

    GameObject card;
    bool cardOut;
    int nextCardNumber = -1;
    [SerializeField] GameObject canvas;

    [SerializeField] GameObject[] cards = new GameObject[CARD_COUNT];

    public void GetCard(int number)
    {
        cardOut = false;
        nextCardNumber = -1;

        card = Instantiate(cards[number]) as GameObject;
        card.transform.SetParent(canvas.transform);
        card.transform.localPosition = new Vector3(0, 400, 0);
    }

    public void ChangeCard(int number)
    {
        card.GetComponent<Animator>().SetTrigger("CardChange");
        cardOut = true;
        nextCardNumber = number;
    }

    void Update()
    {
        if (cardOut && card.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            Destroy(card);
            GetCard(nextCardNumber);
        }
    }

    public void DestroyCard()
    {
        Destroy(card);
    }
}
