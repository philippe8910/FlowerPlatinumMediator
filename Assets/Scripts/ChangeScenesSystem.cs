using System;
using System.Collections;
using System.Collections.Generic;
using Events;
using Project;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Valve.VR.InteractionSystem;

public class ChangeScenesSystem : MonoBehaviour
{
    [SerializeField] private string levelName;

    public GameObject player;
    
    private void OnChangeScenes()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
        Destroy(player);
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
