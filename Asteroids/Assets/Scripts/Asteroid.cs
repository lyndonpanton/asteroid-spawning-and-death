using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An asteroid
/// </summary>
public class Asteroid : MonoBehaviour
{
    [SerializeField]
    Sprite asteroidSprite0;
    [SerializeField]
    Sprite asteroidSprite1;
    [SerializeField]
    Sprite asteroidSprite2;

	/// <summary>
	/// Start is called before the first frame update
	/// </summary>
	void Start()
	{
        Array directions = Enum.GetValues(typeof(Direction));
        int randomDirectionIndex = UnityEngine.Random.Range(0, directions.Length);
        Direction randomDirection = (Direction)directions.GetValue(randomDirectionIndex);

        // set random sprite for asteroid
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        int spriteNumber = UnityEngine.Random.Range(0, 3);
        if (spriteNumber < 1)
        {
            spriteRenderer.sprite = asteroidSprite0;
        }
        else if (spriteNumber < 2)
        {
            spriteRenderer.sprite = asteroidSprite1;
        }
        else
        {
            spriteRenderer.sprite = asteroidSprite2;
        }
	}

    public void Initialize(Direction direction, Vector3 location)
    {
        // apply impulse force to get game object moving
        const float MinImpulseForce = 3f;
        const float MaxImpulseForce = 5f;
        //float angle = .UnityEngine.Random.Range(0, 2 * Mathf.PI);

        float randomAngle = UnityEngine.Random.Range(0, 30) * Mathf.Deg2Rad;
        float baseAngle = 0;

        switch(direction)
        {
            case Direction.Up:
                baseAngle = 75 * Mathf.Deg2Rad;
                break;
            case Direction.Right:
                baseAngle = 345 * Mathf.Deg2Rad;
                break;
            case Direction.Down:
                baseAngle = 255 * Mathf.Deg2Rad;
                break;
            case Direction.Left:
                baseAngle = 165 * Mathf.Deg2Rad;
                break;
        }

        float angle = randomAngle + baseAngle;

        Vector2 moveDirection = new Vector2(
            Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = UnityEngine.Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(
            moveDirection * magnitude,
            ForceMode2D.Impulse);

        transform.position = location;

    }
}
