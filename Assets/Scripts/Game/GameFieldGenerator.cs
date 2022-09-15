using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFieldGenerator : MonoBehaviour
{
    [SerializeField] GameObject hex;
    void Start()
    {
        float hexPosition = transform.position.x;
        for (int i = 0; i < 10; i++)
        {
            GameObject spawnedHex = null;
            for (int j = 0; j < 8; j++)
            {
                spawnedHex = Instantiate(hex, new Vector3(hexPosition, transform.position.y, j + transform.position.z),Quaternion.Euler(0,90,0), transform);
                if (i % 2 == 0)
                {
                    spawnedHex.transform.Translate(0.5f, 0, 0);
                }
                
                spawnedHex.transform.Translate(0,0,0.85f);
            }
            hexPosition = spawnedHex.transform.position.x;
        }
    }
}
