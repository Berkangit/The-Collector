using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldScript : MonoBehaviour
{

    [SerializeField] private float followSpeed;

    public void UpdateGoldPosition(Transform followedGoldBar, bool isFollowStart)
    {
        StartCoroutine(StartFollowingToLastGoldPosition(followedGoldBar, isFollowStart));
    }

    IEnumerator StartFollowingToLastGoldPosition(Transform followedGoldBar, bool isFollowStart)
    {

        while (isFollowStart)
        {
            yield return new WaitForEndOfFrame();
            this.transform.position = new Vector3(Mathf.Lerp(transform.position.x, followedGoldBar.position.x, followSpeed * Time.deltaTime),
                transform.position.y,
                Mathf.Lerp(transform.position.z, followedGoldBar.position.z, followSpeed * Time.deltaTime));
        }
    }
}
