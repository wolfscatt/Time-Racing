using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public Animator tranAnim;
    private void Start() {
        tranAnim.gameObject.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Karakter NextLevel objesiyle temas ettiğinde ve geçiş yapılmadığında
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Transition());
        }
    }

    IEnumerator Transition()
    {
        tranAnim.SetTrigger("end");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
