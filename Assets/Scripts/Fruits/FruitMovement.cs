using UnityEngine;

namespace Fruit 
{
    /// <summary>
    /// Adds movement to full fruits (apples and avocados).
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class FruitMovement : MonoBehaviour
    {
        private Rigidbody rb;
        public float moveSpeed = 10f;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.freezeRotation = true;
        }

        private void FixedUpdate()
        {
            rb.velocity = Vector3.down * moveSpeed * Time.fixedDeltaTime;
        }
    }
}

