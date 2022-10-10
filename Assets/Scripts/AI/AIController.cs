using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField]
    private float shootLoopTime = 5f;

    [SerializeField]
    private float angryLevelLoopTime = 2f;

    [SerializeField]
    private GameObject ballPrefab;

    [SerializeField]
    private Transform rightHand;

    private List<GameObject> availableBallList;

    private GameObject closestBasket;

    private GameObject generatedBall;

    private float angryLevel;

    private void Start()
    {
        ShootBasket();
        AdjustAngryLevel();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("BallBasket"))
        {
            closestBasket = other.gameObject;
            availableBallList = other.GetComponent<BasketStackController>().ballList;
        }
    }

    void ShootBasket()
    {
        if (generatedBall != null)
        {
            generatedBall.GetComponent<Rigidbody>().useGravity = false;
            generatedBall.GetComponent<MeshCollider>().isTrigger = true;
        }
       
        Debug.Log("Shooting!");
        if (availableBallList != null && availableBallList.Count > 0)
        {
            CreateBall();
            ThrowBall();
            Destroy(availableBallList[availableBallList.Count - 1]);
            availableBallList.Remove(availableBallList[availableBallList.Count - 1]);
            closestBasket.GetComponent<BasketStackController>().basketCapacity--;
        }
        System.Random rand = new System.Random();
        double min = 5;
        double max = 7;
        double range = max - min;

        double sample = rand.NextDouble();
        double scaled = (sample * range) + min;
        shootLoopTime = (float)scaled;

        Invoke("ShootBasket", shootLoopTime);
    }

    private void CreateBall()
    {
        generatedBall = Instantiate(ballPrefab, rightHand.position, Quaternion.identity);
        generatedBall.transform.parent = rightHand;
    }

    private void ThrowBall()
    {
        System.Random rand = new System.Random();
        double min = -1;
        double max = 1;
        double range = max - min;

        double sample = rand.NextDouble();
        double scaled = (sample * range) + min;
        float f = (float)scaled;

        generatedBall.transform.parent = null;
        generatedBall.GetComponent<Rigidbody>().useGravity = true;
        generatedBall.GetComponent<MeshCollider>().isTrigger = false;

        if (int.Parse(transform.name) % 2 == 1)
        {
            generatedBall.GetComponent<Rigidbody>().AddForce(new Vector3(-3, 6, f) * 200.0f);
        }
        else if (int.Parse(transform.name) % 2 == 0)
        {
            generatedBall.GetComponent<Rigidbody>().AddForce(new Vector3(3, 6, f) * 200.0f);
        }
    }

    private void AdjustAngryLevel()
    {
        //Debug.Log("Angry Level Increase ");
        if (availableBallList != null && availableBallList.Count <= 0)
        {
            angryLevel += 0.1f;
        }
        else
        {
            angryLevel = 0;
        }
        UIController.Instance.AdjustAngryLevel(int.Parse(transform.name), angryLevel);
        Invoke("AdjustAngryLevel", angryLevelLoopTime);
    }
}
