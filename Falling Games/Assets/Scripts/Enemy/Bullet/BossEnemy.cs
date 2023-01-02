using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossEnemy : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    [SerializeField] private float timeTillNewScene = 2f;

    void Update()
    {
        if(EnemySpawner.isBossDead == true)
        {
            StartCoroutine(DelayEnding());
            EnemySpawner.isBossDead = false;
        }
    }

    private IEnumerator DelayEnding()
    {
        yield return new WaitForSeconds(timeTillNewScene);

        SceneManager.LoadScene("Victory");
    }
}
