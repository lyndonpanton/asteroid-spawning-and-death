using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// A class for creating instances of the asteroid class in the scene
/// </summary>
public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabAsteroid;
    // Start is called before the first frame update
    void Start()
    {
        GameObject upRock = Instantiate(prefabAsteroid) as GameObject;
        GameObject rightRock = Instantiate(prefabAsteroid) as GameObject;
        GameObject downRock = Instantiate(prefabAsteroid) as GameObject;
        GameObject leftRock = Instantiate(prefabAsteroid) as GameObject;

        GameObject[] rocks =
        {
            upRock,
            rightRock,
            downRock,
            leftRock
        };

        upRock.GetComponent<Asteroid>().Initialize(
            Direction.Up
        );

        rightRock.GetComponent<Asteroid>().Initialize(
            Direction.Right
        );

        downRock.GetComponent<Asteroid>().Initialize(
            Direction.Down
        );

        leftRock.GetComponent<Asteroid>().Initialize(
            Direction.Left
        );







    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
