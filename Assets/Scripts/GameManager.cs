using System.Collections;
using System.Collections.Generic;
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

    [SerializeField] private GameObject dieControllerObject;
    private DieController dieController;
    public GameObject diePanel;

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
        dieController = dieControllerObject.GetComponent<DieController>();
        diePanel.SetActive(false);
        Time.timeScale = 1;
    }
    void Update()
    {
        if (dieController.isDead)
        {
            // Oyun Biter ve UI açılır. UI içerisinde Yeniden oyna, çıkış yap ve ana menüye dön butonları bulunur.
            OpenDiePanel();
        }
    }
    private void OpenDiePanel()
    {
        diePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
