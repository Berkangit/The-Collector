using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform finishLineTransform;
    [SerializeField] private Slider slider;

    private float maxDistance;

    // Start is called before the first frame update
    void Start()
    {
        maxDistance = getDistance();
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    private float getDistance()
    {
        return Vector3.Distance(playerTransform.position, finishLineTransform.position);
    }

}
