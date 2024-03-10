using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    public float moveSpeed = 5f; // Hareket hızı
    public float moveDistance = 3f; // Hareket edilecek mesafe
    private bool movingRight = true;
    private Vector3 initialPosition;

    private void Start() {
        initialPosition = transform.position;
    }
    void Update()
    {
        // Hareket vektörü
        Vector3 movement = Vector3.zero;

        // Sağa doğru hareket ediliyorsa
        if (movingRight)
        {
            movement = Vector3.right * moveSpeed * Time.deltaTime;

            // Eğer hareket mesafesi aşıldıysa yönü tersine çevir
            if (transform.position.x >= initialPosition.x + moveDistance)
            {
                movingRight = false;
            }
        }
        else // Sola doğru hareket ediliyorsa
        {
            movement = Vector3.left * moveSpeed * Time.deltaTime;

            // Eğer hareket mesafesi aşıldıysa yönü tersine çevir
            if (transform.position.x <= initialPosition.x - moveDistance)
            {
                movingRight = true;
            }
        }

        // Düşmanı hareket ettir
        transform.Translate(movement);
    }
}
