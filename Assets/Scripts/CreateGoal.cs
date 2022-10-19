using System.Collections;
using UnityEngine;


public class CreateGoal : MonoBehaviour
{
    int posGoal;
    bool IsDestroy = true;

    void Start()
    {
        RandomPosition();
    }

    void RandomPosition()
    {
        posGoal = Random.Range(0, Occupancy._arrayPos.GetLength(1));
        this.transform.position = new Vector2(Occupancy._arrayPos[0, posGoal], Occupancy._arrayPos[1, posGoal]);
    }

    void Update()
    {
        if (IsDestroy)
        {
            RandomPosition();
            IsDestroy = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            IsDestroy = true;
        }
    }

}
