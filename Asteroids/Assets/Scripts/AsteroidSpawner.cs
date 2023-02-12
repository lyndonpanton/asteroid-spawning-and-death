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
    CircleCollider2D prefabAsteroidCC2d;

    CircleCollider2D upRockCC2d;
    CircleCollider2D rightRockCC2d;
    CircleCollider2D downRockCC2d;
    CircleCollider2D leftRockCC2d;

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

        prefabAsteroid = Instantiate(prefabAsteroid) as GameObject;
        prefabAsteroidCC2d = prefabAsteroid.GetComponent<CircleCollider2D>();

        float radius = prefabAsteroidCC2d.radius;
        Destroy(prefabAsteroid);

        upRock.GetComponent<Asteroid>().Initialize(
            Direction.Down,
            new Vector3(
                0,
                ScreenUtils.ScreenTop + radius,
                -Camera.main.transform.position.z
            )
        );

        rightRock.GetComponent<Asteroid>().Initialize(
            Direction.Left,
            new Vector3(
                ScreenUtils.ScreenRight + radius,
                0,
                -Camera.main.transform.position.z
            )
        );

        downRock.GetComponent<Asteroid>().Initialize(
            Direction.Up,
            new Vector3(
                0,
                ScreenUtils.ScreenBottom - radius,
                -Camera.main.transform.position.z
            )
        );

        leftRock.GetComponent<Asteroid>().Initialize(
            Direction.Right,
            new Vector3(
                ScreenUtils.ScreenLeft - radius,
                0,
                -Camera.main.transform.position.z
            )
        );
    }
}
