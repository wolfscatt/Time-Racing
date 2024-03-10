using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class SelectAnyCart : MonoBehaviour
{
    public RectTransform[] carts;
    public GameObject leftTextObject;
    public GameObject rightTextObject;
    public GameObject[] buttons;

    public TextMeshProUGUI[] texts;
    private string[] randomTexts;
    private string selectedText;
    void Start()
    {
        selectedText = "";
        randomTexts = new string[2] { "Die", "Continue" };

        // Başlangıçta Textler gizli
        leftTextObject.SetActive(false);
        rightTextObject.SetActive(false);

        SetRandomText();
    }
    void SelectedText()
    {
        if (selectedText == "Die")
        {
            GameManager.Instance.GameOver();
        }
        else if (selectedText == "Continue")
        {
            GameManager.Instance.ResumeGame();
        }
    }

    void SetRandomText()
    {
        // Rastgele bir indeks seç
        int randomIndex = GetRandomIndex();
        int randomIndex2 = GetRandomIndex();

        // Rastgele seçilen metni 'texts' dizisindeki tüm metinlere ata
        texts[0].text = randomTexts[randomIndex];
        texts[1].text = randomTexts[randomIndex2];
    }
    int GetRandomIndex()
    {
        return Random.Range(0, randomTexts.Length);
    }

    // GetText() metodu butonlara tıklandığında çalışacak.
    public void GetText(int buttonId)
    {
        // Kartlardan birine tıklandığında onları döndür
        foreach (var cart in carts)
        {
            cart.DORotate(new Vector3(0, 180, 0), 1f).From().SetEase(Ease.Flash);
        }

        // Önce Textleri aktif et
        leftTextObject.SetActive(true);
        rightTextObject.SetActive(true);

        // Textlerin RectTransform'lerini al
        var leftTextRect = leftTextObject.GetComponent<RectTransform>();
        var rightTextRect = rightTextObject.GetComponent<RectTransform>();

        // Textleri ekrana doğru hareket ettir
        leftTextRect.DOAnchorPosX(-900, 1f).From().SetEase(Ease.OutBounce);
        rightTextRect.DOAnchorPosX(900, 1f).From().SetEase(Ease.OutBounce);

        Debug.Log("Button ID: " + buttonId);

        // Seçilen butonun textini al
        selectedText = buttons[buttonId].GetComponentInChildren<TextMeshProUGUI>().text;
        if (selectedText != null)
        {
            Debug.Log("Button " + buttonId + " text: " + selectedText);
            StartCoroutine(WaitAndCallSelectedText());

        }
        else
        {
            Debug.LogWarning("Button " + buttonId + " text not found!");
        }
    }
    IEnumerator WaitAndCallSelectedText()
    {
        yield return new WaitForSeconds(2f);
        SelectedText();
    }

}
