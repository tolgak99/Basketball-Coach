using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BasketStackController : MonoBehaviour
{
    public int basketCapacity = 0;

    [SerializeField]
    private GameObject ballPrefab;

    [SerializeField]
    private float ballSpawnOffset_Y = 1f;

    public List<GameObject> ballList;

    public void PlaceBalls(int maxBallCount,int ballCount)
    {
        for (int i=0; i < ballCount; i++)
        {
            if (basketCapacity >= maxBallCount)
            {
                return;
            }


            if (basketCapacity % 4 == 0)
            {
                CreateBall(0);
                basketCapacity++;
            }
            else if (basketCapacity % 4 == 1)
            {
                CreateBall(1);
                basketCapacity++;
            }
            else if (basketCapacity % 4 == 2)
            {
                CreateBall(2);
                basketCapacity++;
            }
            else if (basketCapacity % 4 == 3)
            {
                CreateBall(3);
                basketCapacity++;
            }
        }
    }


    public void CreateBall(int childIndex)
    {
        Transform anchorPoint = transform.GetChild(childIndex);
        Vector3 pos = Vector3.zero;
        Vector3 localScale = Vector3.zero;

        GameObject creatingPrefab = null;
        GameObject obj = null;

        creatingPrefab = ballPrefab;
        pos = new Vector3(
          anchorPoint.position.x,
          anchorPoint.position.y + (ballSpawnOffset_Y * (basketCapacity / 4)),
          anchorPoint.position.z
        );

        obj = Instantiate(creatingPrefab, pos, Quaternion.identity);
        obj.transform.parent = transform;
        obj.GetComponent<Rigidbody>().useGravity = false;
        obj.GetComponent<MeshCollider>().isTrigger = true;
        Destroy(obj.GetComponent<BallController>());
        ballList.Add(obj);
    }

}
