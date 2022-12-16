using System;
using UnityEngine;

namespace Helpers
{
    public class DeathLine : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            var isBall = string.Equals(collision.gameObject.tag, Constants.TagBall);
            if (isBall)
            {
                collision.gameObject.GetComponent<Ball>().Failed();
            }
        }
    }
}
