using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private void Awake()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        GameObject[] gameMusicObjects = GameObject.FindGameObjectsWithTag("GameMusic");
        GameObject[] menuMusicObjects = GameObject.FindGameObjectsWithTag("MenuMusic");

        if(sceneIndex == 0 || sceneIndex == 2)
        {
            foreach (GameObject gameMusicObject in gameMusicObjects)
            {
                Destroy(gameMusicObject);
            }
            if (menuMusicObjects.Length > 1)
            {
                Destroy(this.gameObject);
            }
            DontDestroyOnLoad(this.gameObject);
        }
        else if(sceneIndex == 1)
        {
            foreach (GameObject menuMusicObject in menuMusicObjects)
            {
                Destroy(menuMusicObject);
            }
        }
    }
}
