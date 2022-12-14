using UnityEngine;

public class DeathLine : MonoBehaviour
{
    private const string Ball = "Ball";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == Ball)
        {
            collision.gameObject.GetComponent<Ball>().Failed();
        }
    }
}
