using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
  
    public static GameManager gameManagerInstance;
     public bool gameState;
    
    [SerializeField]private GameObject menuAvoids;
    [SerializeField] private GameObject gameStartedUI;
   


    
    private void Awake()
    {
       
        gameManagerInstance = this;
    }

    private void Start()
    {
        gameState = false;
    }

    public void TapToScreen()
    {
        gameState = true;
        Time.timeScale = 1f;
        menuAvoids.SetActive(false);
        gameStartedUI.SetActive(true);
    }
    
}
