using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    public BottleRefresher mySpawner;

    public GameObject bottleDestructedPrefab;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void GotShot(Vector3 exploPos) {
        mySpawner.InitializeNewBottle();

        gameManager.IncreaseScore();

        if(!gameManager.gameStarted) 
        gameManager.gameStarted = true;

        GameObject destObj = Instantiate(bottleDestructedPrefab, transform.position, transform.rotation);
        destObj.transform.localScale = transform.localScale;

        foreach (MeshCollider meshColl in destObj.GetComponentsInChildren<MeshCollider>())
        {
            meshColl.convex = true;
            Rigidbody destructedRb = meshColl.gameObject.AddComponent<Rigidbody>();
            destructedRb.AddExplosionForce(300, exploPos, 5);
        }


        Destroy(destObj.gameObject, 3);
        Destroy(gameObject);
       
    }
}
