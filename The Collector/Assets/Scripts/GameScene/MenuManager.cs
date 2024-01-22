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
    public static MenuManager Instance { get; private set; }
   

    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform finishLineTransform;
    [SerializeField] private Slider slider;
    [SerializeField] private Vector3 newGoldCountTransform = new Vector3(1.5f,1.5f,1.5f);

    private float maxDistance;

    private void Awake()
    {
        Instance = this;
  
    }

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

       
    }

    private float getDistance()
    {
        return Vector3.Distance(playerTransform.position, finishLineTransform.position);
    }

    private void setProgresss(float p)
    {
        slider.value = p;
    }

    public void UpdateGoldCount()
    {
        goldCountText.transform.DOScale(newGoldCountTransform, 0.3f)
          .OnComplete(() => OnScaleComplete());
           //nsform.DOMove(randomStartPosition, speed)
           //.OnComplete(() => OnMoveComplete());


        goldCountText.text = playerScript.goldBarList.Count.ToString();
    }

    private void OnScaleComplete()
    {
        goldCountText.transform.DOScale(new Vector3(1f, 1f, 1f), 0.3f);
    }
}
