using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class MoveSpecificGate : MonoBehaviour
{

    //Speed can be change but for now its good 

    [SerializeField] private Vector3 limitA = new Vector3(3.5f, 2.9f, 0f);
    [SerializeField] private Vector3 limitB = new Vector3(-3.5f, 2.9f, 0f);
    // [SerializeField] private float[] speeds = {1f,0.8f,0.5f,0.2f};
    //[SerializeField] private float selectedRandomSpeed;
    [SerializeField] private float speed = 0.7f;

    private void Start()
    {
        float anchorZ = transform.position.z;

        limitA.z = anchorZ;
        limitB.z = anchorZ;


        RandomMoveToLimits();
 
    }



    private void RandomMoveToLimits()
    {
        Vector3 randomStartPosition = Random.Range(0, 2) == 0 ? limitA : limitB;

       //  selectedRandomSpeed = GetRandomSpeed();
       // Debug.Log(selectedRandomSpeed);

         transform.DOMove(randomStartPosition, speed)
           .OnComplete(() => OnMoveComplete());
    }


    //private float GetRandomSpeed()
    //{
    //    int randomIndex = Random.Range(0, speeds.Length);
    //    float selectedSpeed = speeds[randomIndex];
    //    return selectedSpeed;
    //}

    void OnMoveComplete()
    {
        // Hareket tamamlandýðýnda bu fonksiyon çaðrýlýr
        Vector3 finalPosition = transform.position;
        //tweener.SetEase(Ease.InOutQuad);
        //tweener.SetLoops(int.MaxValue, LoopType.Yoyo);

        if (finalPosition.x == limitA.x)
        {
            transform.DOMove(limitB, speed).
                SetEase(Ease.InOutQuad).
                SetLoops(int.MaxValue, LoopType.Yoyo);
        }
        else
        {
            transform.DOMove(limitA, speed).
            SetEase(Ease.InOutQuad).
                SetLoops(int.MaxValue, LoopType.Yoyo);

        }



    }

}
