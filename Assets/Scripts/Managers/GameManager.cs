using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int deadEnemyCount; // Ölen düşman sayısı
    public int totalEnemyCount;
    public string nextSceneName; // Geçilecek bir sonraki sahnenin adı

    public void IncreaseDeadEnemyCount()
    {
        deadEnemyCount++;

        if (deadEnemyCount >= totalEnemyCount)
        {
            SceneManager.LoadScene(nextSceneName);
        }

        
    }
}
