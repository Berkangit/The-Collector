using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GateManager : MonoBehaviour
{
    [SerializeField] private TMP_Text gateNumberText = null;
    [SerializeField] private enum GateType
    {
        positiveGate,
        negativeGate
    }
    [SerializeField] private GateType typeOfGate;
    [SerializeField] private int gateNumber;
   

  
    public int GetGateNumber()
    {
        return gateNumber;
    }

    private void Start()
    {
       
            GenerateRandomGateRumber();
            
    }

    private void GenerateRandomGateRumber()
    {
        switch(typeOfGate)
        {
            case GateType.positiveGate:
                gateNumber = Random.Range(1, 10);
                gateNumberText.text = gateNumber.ToString();
                break;
            case GateType.negativeGate:
                gateNumber = Random.Range(-10, -1);
                gateNumberText.text = gateNumber.ToString();
                break;

        }

    }
}
