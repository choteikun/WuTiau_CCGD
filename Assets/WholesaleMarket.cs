using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WholesaleMarket : MonoBehaviour
{
    [SerializeField]
    private MyStore playerStore;

    private int itemPrice;
    private int costPerHire;//���Ħ���
    
    void Start()
    {
        playerStore = GetComponent<MyStore>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
