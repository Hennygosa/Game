using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public int numberOfEnemies;

    private void Update()
    {
        numberOfEnemies = GameObject.FindGameObjectsWithTag("EnemyRanged").Length
            + GameObject.FindGameObjectsWithTag("EnemyMelee").Length;
        if (numberOfEnemies == 0)
        {
            ShowExit();
        }
    }
    public void ShowExit()
    {
        transform.position = new Vector3(0, 3, 195);
    }


    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if (SceneManager.GetActiveScene().buildIndex + 1 == SceneManager.sceneCountInBuildSettings)
                SceneManager.LoadScene(0);
            else
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
