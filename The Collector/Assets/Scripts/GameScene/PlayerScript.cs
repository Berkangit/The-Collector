using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody playerRB;
    //--------------Movement---------------
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float horizontalLimit;

    private float horizontal;


    [SerializeField] private TMP_Text goldCountText = null;
    
 
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject goldPrefab;

    List<GameObject> goldBarList = new List<GameObject>();
    private Vector3 firstGoldPos , currentGoldPos;
    private int goldBarListIndexCounter = 0;
    private const string GOLD_TAG_STRING = "Gold";
    private const string GATE_TAG_STRING = "Gate";
    private int gateNumber;
    private int targetCount;


    private void Awake()
    {
        playerRB = this.gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(GameManager.gameManagerInstance.gameState)
        {
            HorizontalMove();
            ForwardMove();
            UpdateGoldCount();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(GOLD_TAG_STRING))
        {
            goldBarList.Add(other.gameObject);

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
            } 
            else if (gateNumber < 0)
            {

                if (goldBarList.Count >= Mathf.Abs(gateNumber))
                {
                    Debug.Log("Decrease gold called");

                    Debug.Log("target count :" + targetCount);
                    Debug.Log("target count :" + goldBarList.Count);
                    DecreaseGold();
                }

                else
                {
                    Debug.Log("Eldeki kurtarmadý");
                    for(int i= goldBarList.Count -1; i >= 0; i--)
                    {
                        GameObject goldToRemove = goldBarList[i];
                        Destroy(goldToRemove);
                    }
                    goldBarList.Clear();
                    goldBarListIndexCounter = 0;
                }
            }

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
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }


    private void IncreaseGold()
    {
        for(int i=0; i< gateNumber; i++)
        {
            GameObject newGold = Instantiate(goldPrefab);
            newGold.gameObject.transform.position = currentGoldPos;
            currentGoldPos = new Vector3(newGold.transform.position.x, newGold.gameObject.transform.position.y + 0.3f, newGold.transform.position.z);
            newGold.gameObject.GetComponent<GoldScript>().UpdateGoldPosition(goldBarList[goldBarListIndexCounter].transform, true);
            goldBarList.Add(newGold);
            goldBarListIndexCounter++;
        }
    }

    private void DecreaseGold()
    {

            for (int i = goldBarList.Count - 1; i >= targetCount; i--)
            {
                GameObject goldToRemove = goldBarList[i];
                goldBarList.RemoveAt(i);
                goldBarListIndexCounter--;
                Destroy(goldToRemove);
            }
       
       

        if (goldBarList.Count > 0)
        {
            currentGoldPos = goldBarList[goldBarList.Count - 1].transform.position;
            currentGoldPos.y += 0.3f;
        }
    }


    private void UpdateGoldCount()
    {
        goldCountText.text = goldBarList.Count.ToString();
    }


   
}
