using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tapToStartText;
    [SerializeField] private GameObject handIcon;
    [SerializeField] private TMP_Text goldCountText = null;
    [SerializeField] private PlayerScript playerScript;

    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform finishLineTransform;
    [SerializeField] private Slider slider;

    private float maxDistance;

   
    private void Start()
    {
        maxDistance = getDistance();

        if(GameManager.gameManagerInstance.gameState == false)
        {
                tapToStartText.transform.
                DOScale(1.1f, 0.5f).
                SetLoops(10000, LoopType.Yoyo).
                SetEase(Ease.InOutFlash);
            
                handIcon.GetComponent<RectTransform>().
                 DOAnchorPosX(-12f, 1f)
                .SetLoops(100000, LoopType.Yoyo)
               .SetEase(Ease.InOutFlash);
            
        }       
       
    }

    void Update()
    {
        if (playerTransform.position.z <= maxDistance && playerTransform.position.z <= finishLineTransform.position.z)
        {
            float distance = 1 - (getDistance() / maxDistance);
            setProgresss(distance);
        }

        UpdateGoldCount();
    }

    private float getDistance()
    {
        return Vector3.Distance(playerTransform.position, finishLineTransform.position);
    }

    private void setProgresss(float p)
    {
        slider.value = p;
    }

    private void UpdateGoldCount()
    {
        goldCountText.text = playerScript.goldBarList.Count.ToString();
    }
}
