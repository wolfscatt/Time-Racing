using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DieController : MonoBehaviour
{
    public GameObject diePanel;
    private bool _isDead;

    private void Start()
    {
        diePanel.SetActive(false);
        Time.timeScale = 1;
    }
    private void Update()
    {
        _isDead = GameManager.Instance.isDead;
        DiePanel();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.GameOver();
        }
    }

    private void DiePanel()
    {
        if (_isDead)
        {
            diePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
