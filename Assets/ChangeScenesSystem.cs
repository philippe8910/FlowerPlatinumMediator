using System;
using System.Collections;
using System.Collections.Generic;
using Events;
using Project;
using UnityEngine;

public class ChangeScenesSystem : MonoBehaviour
{
    [SerializeField] private string levelName;
    
    private void OnChangeScenes()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
        EventBus.CleanUpAllData();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventBus.Post(new ChangeLevelDetected(OnChangeScenes , true));
        }
    }
}
