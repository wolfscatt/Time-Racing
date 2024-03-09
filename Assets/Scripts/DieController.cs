using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieController : MonoBehaviour
{
    public GameObject diePanel;
    public bool isDead = false;

    private void Start()
    {
        isDead = false;
        diePanel.SetActive(false);
        Time.timeScale = 1;

    }
    private void Update()
    {
        DiePanel();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isDead = true;
        }
    }

    private void DiePanel()
    {
        if (isDead)
        {
            diePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
