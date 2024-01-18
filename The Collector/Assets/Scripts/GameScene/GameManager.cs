using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
  
    public static GameManager gameManagerInstance;
     public bool gameState;
    private Animator animator;
    [SerializeField]private GameObject menuAvoids;
   


    private const string IS_RUNNING = "isRunning";
    private void Awake()
    {
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        gameManagerInstance = this;
    }

    private void Start()
    {
        gameState = false;
    }

    public void TapToScreen()
    {
        gameState = true;
        animator.SetBool(IS_RUNNING, true);
        menuAvoids.SetActive(false);
        

    }



    
}
