using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public Transform Coin;

    List<Transform> coinList;
    //Random rnd = new Random();
    // Start is called before the first frame update
    void Start()
    {
        //coinList = new List<Transform>();
            
            
            
                Transform t = Instantiate(Coin);
                Transform p = transform.GetChild(1);

                t.parent = p;
                t.localPosition = p.localPosition;
            
        
        //coinList.Add(Coin);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
