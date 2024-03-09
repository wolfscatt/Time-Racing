using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collects : MonoBehaviour
{
    public GameObject countDownTimer;
    private CountDownTimer countDown;

    private void Start() 
    {
        countDown = countDownTimer.GetComponent<CountDownTimer>();
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            // Burada Collect sesi çalınacak. Ve Süre arttırılacak.
            Destroy(gameObject);
            countDown.IncreaseTime(5f);
        }
    }
}
