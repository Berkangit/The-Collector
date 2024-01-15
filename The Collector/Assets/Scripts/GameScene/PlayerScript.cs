using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private Transform player;
    private Vector3 startMousePos, startPLayerPos;
    [SerializeField] private bool moveThePlayer;
    [SerializeField] private float maxSpeed, pathSpeed, velocity;
    public Transform path;
  

    private void Start()
    {
        player = transform;
        maxSpeed = 0.5f;
    }

    private void Update()
    {


        if (Input.GetMouseButtonDown(0) && GameManager.gameManagerInstance.gameState)
        {
            moveThePlayer = true;


            Plane newPlan = new Plane(Vector3.up, 0f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (newPlan.Raycast(ray, out var distance))
            {
                startMousePos = ray.GetPoint(distance);
                startPLayerPos = player.position;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            moveThePlayer = false;

        }
        if (moveThePlayer)
        {
            Plane newPlan = new Plane(Vector3.up, 0f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (newPlan.Raycast(ray, out var distance))
            {
                Vector3 mouseNewPos = ray.GetPoint(distance);
                Vector3 MouseNewPos = mouseNewPos - startPLayerPos;
                Vector3 DesirePlayerPos = mouseNewPos + startPLayerPos;


                DesirePlayerPos.x = Mathf.Clamp(DesirePlayerPos.x, -4.0f,4.0f);

                player.position = new Vector3(Mathf.SmoothDamp(player.position.x, DesirePlayerPos.x, ref velocity, maxSpeed)
                 , player.position.y, player.position.z);
            }

        }
        if (GameManager.gameManagerInstance.gameState)
        {

            var pathNewPos = path.position;
            path.position = new Vector3(path.position.x, path.position.y, Mathf.MoveTowards(pathNewPos.z, -450f, pathSpeed * Time.deltaTime));


        }



    }


}
