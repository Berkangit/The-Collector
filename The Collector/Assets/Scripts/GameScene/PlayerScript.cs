using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody playerRB;
    private bool MoveByTouch;
    private Vector3 Direction;
    private Vector3 startMousePos, startPLayerPos;
    [SerializeField] private float runSpeed, velocity, swipeSpeed, roadSpeed;
    [SerializeField] private Transform road;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject holderPoint;

    



    List<GameObject> goldBarList = new List<GameObject>();

    private Vector3 firstGoldPos , currentGoldPos;
    private int goldBarListIndexCounter = 0;

    private const string GOLD_TAG_STRING = "Gold";


    private void Awake()
    {
        playerRB = this.gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.gameManagerInstance.gameState)
        {
            MoveByTouch = true;

            Plane newPlan = new Plane(Vector3.up, 0f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (newPlan.Raycast(ray, out var distance))
            {
                startMousePos = ray.GetPoint(distance);
                startPLayerPos = playerRB.position;
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            MoveByTouch = false;
        }

        if(MoveByTouch)
        {
            Plane newPlan = new Plane(Vector3.up, 0f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (newPlan.Raycast(ray, out var distance))
            {
                Vector3 mouseNewPos = ray.GetPoint(distance);
                Vector3 MouseNewPos = mouseNewPos - startPLayerPos;
                Vector3 DesirePlayerPos = mouseNewPos + startPLayerPos;


                DesirePlayerPos.x = Mathf.Clamp(DesirePlayerPos.x, -3.3f, 3.3f);

                playerRB.position = new Vector3(Mathf.SmoothDamp(playerRB.position.x, DesirePlayerPos.x, ref velocity, runSpeed)
                 , playerRB.position.y, playerRB.position.z);
            }
        }

        if (GameManager.gameManagerInstance.gameState)
        {
            Debug.Log(GameManager.gameManagerInstance.gameState);

            var pathNewPos = road.position;
            road.position = new Vector3(road.position.x, road.position.y, Mathf.MoveTowards(pathNewPos.z, -100f, roadSpeed * Time.deltaTime));


        }
    }


    private void FixedUpdate()
    {
        if (MoveByTouch)
        {
            Vector3 displacement = new Vector3(Direction.x, 0f, 0f) * Time.fixedDeltaTime;

            playerRB.velocity = new Vector3(Direction.x * Time.fixedDeltaTime * swipeSpeed,0f,0f) + displacement;
        }
        else
        {
            playerRB.velocity = Vector3.zero;
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(GOLD_TAG_STRING))
        {
            goldBarList.Add(other.gameObject);

            Debug.Log(goldBarList);

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
    }


   
}
