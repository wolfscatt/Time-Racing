using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDownTimer : MonoBehaviour
{
    public TextMeshProUGUI countDownText;
    public float countDownTime = 20f;
    void Start()
    {
        countDownText.text = $"{countDownTime}";
        StartCoroutine(StartCountDown());
    }

    private IEnumerator StartCountDown()
    {
        // float currentTime = countDownTime;

        while (countDownTime > 0f)
        {
            // Zamanı güncelle ve ekranda göster
            countDownText.text = countDownTime.ToString("F0");

            // Zamanı azalt
            countDownTime -= 1f;

            // Bir saniye bekle
            yield return new WaitForSeconds(1f);
        }
        if(countDownTime <= 0f)
        {
            GameManager.Instance.GameOver();
        }

        // Geri sayım tamamlandığında ekranda "Başla!" yazısı gösterilebilir
    }
    public void IncreaseTime(float amount)
    {
        countDownTime += amount;
    }
}
