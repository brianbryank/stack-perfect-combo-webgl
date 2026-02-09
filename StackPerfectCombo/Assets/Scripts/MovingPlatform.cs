using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 2f;
    public float limit = 3f;

    private bool movingRight = true;

    void Update()
    {
        float move = speed * Time.deltaTime;
        transform.Translate(movingRight ? move : -move, 0, 0);

        if (transform.position.x > limit) movingRight = false;
        if (transform.position.x < -limit) movingRight = true;
    }

    public void IncreaseDifficulty()
    {
        speed += 0.3f;
    }
}
