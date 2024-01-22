using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
  

    //--------------Movement---------------
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float horizontalLimit;

    private float horizontal;



    [SerializeField] private GameOverManager gameOverManager;
    [SerializeField] private HealthManager healthManager;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject goldPrefab;
    [HideInInspector] public bool isFinishLineTouched = false;
    [HideInInspector] public bool isPlayerDead = false;

   [HideInInspector]public List<GameObject> goldBarList = new List<GameObject>();
    private Vector3 firstGoldPos , currentGoldPos;
    private int goldBarListIndexCounter = 0;
    private const string GOLD_TAG_STRING = "Gold";
    private const string GATE_TAG_STRING = "Gate";
    private const string FINISH_LINE_STRING = "FinishLine";
    private int gateNumber;
    private int targetCount;

    private Animator animator;
    private const string IS_RUNNING = "isRunning";
    private const string IS_DEATH = "isDeath";
    private const string IS_FINISHED = "isFinished";

    
    private void Awake()
    {
        animator = this.gameObject.transform.GetChild(0).GetComponent<Animator>();
    }

    private void Update()
    {
        if(GameManager.gameManagerInstance.gameState)
        {
            
            HorizontalMove();
            ForwardMove();
           
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(GOLD_TAG_STRING))
        {
            goldBarList.Add(other.gameObject);

            MenuManager.Instance.UpdateGoldCount();

            SoundManager.instance.PlayCoinSounds();

            Debug.Log(goldBarList.Count);
            if(goldBarList.Count == 1)
            {

                firstGoldPos = this.gameObject.transform.GetChild(0).GetComponent<Collider>().bounds.max;
                currentGoldPos = new Vector3(other.transform.position.x, firstGoldPos.y, other.transform.position.z);
                other.gameObject.transform.position = currentGoldPos;
                currentGoldPos = new Vector3(other.transform.position.x, transform.position.y + 3f, other.transform.position.z);
                other.gameObject.GetComponent<GoldScript>().UpdateGoldPosition(transform, true);
            }
            else if(goldBarList.Count > 1)
            {
                other.gameObject.transform.position = currentGoldPos;
                currentGoldPos = new Vector3(other.transform.position.x, other.gameObject.transform.position.y + 0.3f, other.transform.position.z);
                other.gameObject.GetComponent<GoldScript>().UpdateGoldPosition(goldBarList[goldBarListIndexCounter].transform, true);
                goldBarListIndexCounter++;

            }

        }

        if(other.gameObject.CompareTag(GATE_TAG_STRING))
        {
            gateNumber = other.gameObject.GetComponent<GateManager>().GetGateNumber();
            targetCount = goldBarList.Count + gateNumber;

            if(gateNumber > 0)
            {
                IncreaseGold();
                SoundManager.instance.auidioSource.PlayOneShot(SoundManager.instance.multipleCoinSoundClip);
                MenuManager.Instance.UpdateGoldCount();
               
            } 
            else if (gateNumber < 0)
            {
               

                if (goldBarList.Count >= Mathf.Abs(gateNumber))
                {
                    Debug.Log("Decrease gold called");

                    Debug.Log("target count :" + targetCount);
                    Debug.Log("target count :" + goldBarList.Count);
                    SoundManager.instance.auidioSource.PlayOneShot(SoundManager.instance.coinDropSoundClip);
                    DecreaseGold();
                }

                else
                {
                    Debug.Log("Eldeki kurtarmadý");
                    SoundManager.instance.auidioSource.PlayOneShot(SoundManager.instance.punchSoundClip);
                    if (healthManager.numberOfHearts > 0)
                    {
                        for (int i = goldBarList.Count - 1; i >= 0; i--)
                        {
                            GameObject goldToRemove = goldBarList[i];
                            Destroy(goldToRemove);
                        }
                        goldBarList.Clear();
                        goldBarListIndexCounter = 0;
                        healthManager.numberOfHearts--;

                        if(healthManager.numberOfHearts == 0)
                        {
                            Death();
                        }
                    } 
                }
                MenuManager.Instance.UpdateGoldCount();
            }

        }

        if(other.gameObject.CompareTag(FINISH_LINE_STRING))
        {
            Debug.Log("Game is finished");
            GameManager.gameManagerInstance.gameState = false;
            isFinishLineTouched = true;
            animator.SetBool(IS_FINISHED,true);

            if (goldBarList.Count > PlayerPrefs.GetInt("HighGold", 0)) 
            PlayerPrefs.SetInt("HighGold", goldBarList.Count);
        }
    }
      
    private void HorizontalMove()
    {
        float newX;

        if(Input.GetMouseButton(0))
        {
            horizontal = Input.GetAxisRaw("Mouse X");
        }

        newX = transform.position.x + horizontal * horizontalSpeed * Time.deltaTime;

        newX = Mathf.Clamp(newX, -horizontalLimit, horizontalLimit);

        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

    private void ForwardMove()
    {
        animator.SetBool(IS_RUNNING, true);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }


    private void IncreaseGold()
    {
        if (goldBarList.Count > 0)
        {
            for (int i = 0; i < gateNumber; i++)
            {
                GameObject newGold = Instantiate(goldPrefab);
                newGold.gameObject.transform.position = currentGoldPos;
                currentGoldPos = new Vector3(newGold.transform.position.x, newGold.gameObject.transform.position.y + 0.3f, newGold.transform.position.z);
                newGold.gameObject.GetComponent<GoldScript>().UpdateGoldPosition(goldBarList[goldBarListIndexCounter].transform, true);
                goldBarList.Add(newGold);
                goldBarListIndexCounter++;
            }
        }
    }

    private void DecreaseGold()
    {
        Debug.Log("Before gold decreased " + goldBarListIndexCounter);
            for (int i = goldBarList.Count - 1; i >= targetCount; i--)
            {
                GameObject goldToRemove = goldBarList[i];
                goldBarList.RemoveAt(i);
                goldBarListIndexCounter--;
                Destroy(goldToRemove);
            }

        if (goldBarListIndexCounter < 0)
            goldBarListIndexCounter = 0;

        Debug.Log("After gold decreased " + goldBarListIndexCounter);



        if (goldBarList.Count > 0)
        {
            currentGoldPos = goldBarList[goldBarList.Count - 1].transform.position;
            currentGoldPos.y += 0.3f;
        }
    }


  

    private void Death()
    {
        Debug.Log("You are dead");
        SoundManager.instance.auidioSource.PlayOneShot(SoundManager.instance.deathSoundClip);
        animator.SetBool(IS_DEATH, true);
        moveSpeed = 0f;
        horizontalSpeed = 0f;
        isPlayerDead = true;
      
    }


   
}
