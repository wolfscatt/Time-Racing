using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    [AllowNull]
    public GameObject riskPanel;
    public bool isDead = false;
    private void Awake() {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        isDead = false;
        Time.timeScale = 1;
        riskPanel.SetActive(false);
    }
    void Update()
    {
        Risk();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void GameOver()
    {
        isDead = true;
        riskPanel.SetActive(false);
    }
    public void StopGame()
    {
        Time.timeScale = 0;
        riskPanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        riskPanel.SetActive(false);
    }
    private void Risk()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            // Burada bir panel açılacak ve oyuncunun karşısına 2 tane kart çıkacak. Bir tanesinde ölüm bir tanesinde devam edecek.
            StopGame();
        }
    }
}
