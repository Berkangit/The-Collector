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

    private void Start()
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
