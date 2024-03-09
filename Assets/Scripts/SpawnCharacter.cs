using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacter : MonoBehaviour
{
    public GameObject characterPrefab; // Karakterinizin prefab'ı
    private Vector3 spawnPoint; // Karakterin spawn olacağı nokta
    public GameObject spawnEffectPrefab; // Spawn efekti prefab'ı
    public float spawnTime = 2f; // Spawn süresi

    private void Start()
    {
        StartCoroutine(SpawnCharacterWithEffect());
        spawnPoint = new Vector3(-7.72f, -1.4f, 0);
    }

    private IEnumerator SpawnCharacterWithEffect()
    {
        yield return new WaitForSeconds(spawnTime);

        // Spawn efektini oluştur
        GameObject spawnEffect = Instantiate(spawnEffectPrefab, transform.position, Quaternion.identity);

        // Karakteri yavaş yavaş spawn et
        float elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime / spawnTime;
            yield return null;
        }

        // Spawn efektini yok et
        Destroy(spawnEffect);

        // Karakteri spawn et
        GameObject character = Instantiate(characterPrefab, spawnPoint, Quaternion.identity);
    }
}
