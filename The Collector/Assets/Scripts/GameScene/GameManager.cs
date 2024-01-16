using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance;
     public bool gameState;
    private Animator animator;
    [SerializeField]private GameObject menuCanvas;


    private const string IS_RUNNING = "isRunning";
    private void Awake()
    {
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    private void Start()
    {
        gameManagerInstance = this;
        gameState = false;
    }

    public void TapToScreen()
    {
        gameState = true;
        animator.SetBool(IS_RUNNING, true);
        menuCanvas.SetActive(false);

    }

}
