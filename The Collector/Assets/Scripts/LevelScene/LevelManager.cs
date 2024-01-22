using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationClip[] danceAnimClip;
    private const string DANCE_INDEX = "DanceIndex";
    private const string DANCE = "Dance";


    private void Start()
    {
        int randomDanceIndex = Random.Range(0, 3);
        animator.SetInteger(DANCE_INDEX, randomDanceIndex);
        animator.SetTrigger(DANCE);
    }

}
