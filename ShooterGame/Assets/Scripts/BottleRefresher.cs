using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleRefresher : MonoBehaviour
{
    public GameObject bottlePrefab;
    bool bottleOnTheWay;

    
    void Start()
    {
        SpawnNewBottle();
    }

    public void InitializeNewBottle() {

        if (bottleOnTheWay == true)
        return;


        bottleOnTheWay = true;
        Invoke("SpawnNewBottle", 4);
    }

    private void SpawnNewBottle()
    {
        GameObject myBottle = Instantiate(bottlePrefab, transform.position, Quaternion.identity);
        bottleOnTheWay = false;

        myBottle.transform.localScale = transform.parent.transform.localScale; 

        myBottle.GetComponent<Bottle>().mySpawner = this;
    }

}
