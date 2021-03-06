using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public int numberOfEnemies;

    private bool areEnemiesDead = false;

    private void Update()
    {
        numberOfEnemies = GameObject.FindGameObjectsWithTag("EnemyRanged").Length
            + GameObject.FindGameObjectsWithTag("EnemyMelee").Length;
        if (numberOfEnemies == 0 && !areEnemiesDead)
        {
            areEnemiesDead = true;
            ShowExit();
        }
    }
    public void ShowExit()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 4f, transform.position.z);
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
