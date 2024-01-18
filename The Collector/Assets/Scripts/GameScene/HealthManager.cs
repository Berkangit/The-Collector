using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
     public int numberOfHearts = 3;

    public Image[] hearts;

    public Sprite fullHeart;

    private void Update()
    {
        for(int i = 0; i< hearts.Length ; i++)
        {
            
            if( i< numberOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

}
