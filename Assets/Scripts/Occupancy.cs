using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Occupancy : MonoBehaviour
{
    public GameObject OccupancyPrefab;
    public static GameObject[,] _dublicate = new GameObject[15,12];
    public static float[,] _arrayPos;


    float totalY = 4f;
    float totalX = -1.88f;
    float total;
    int index = 0;

    void OccupancyList()
    {
        _arrayPos = new float[2, (_dublicate.GetLength(0) * _dublicate.GetLength(1))];
        total = totalX;

        for (int i = 0; i < _dublicate.GetLength(0); i++)
        {
            for (int j = 0; j < _dublicate.GetLength(1); j++)
            {
                _arrayPos[0, index] = totalX;
                _arrayPos[1, index] = totalY;
                index++;
                _dublicate[i, j] = OccupancyPrefab;
                Instantiate(_dublicate[i,j], new Vector2( totalX,  totalY), Quaternion.identity);

                totalX += 0.34f;
            }
            totalY -= 0.34f;
            totalX = total;
        }
    }
   
    void Awake()
    {
        OccupancyList();
    }
}
