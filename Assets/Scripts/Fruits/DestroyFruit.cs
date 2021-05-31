using UnityEngine;

namespace Fruit
{
    public class DestroyFruit : MonoBehaviour
    {
        private void OnTriggerExit(Collider other)
        {
            Destroy(other.gameObject);
        }
    }
}

