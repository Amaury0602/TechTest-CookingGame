using UnityEngine;

namespace Fruit 
{
    /// <summary>
    /// Add this object to any gameObject that has a cut mesh.
    /// </summary>
    public class Sliceable : MonoBehaviour
    {
        [SerializeField] private GameObject cutObject;

        public void Slice()
        {
            if (!cutObject) return;
            for (int i = 0; i < 2; i++)
            {
                Instantiate(cutObject, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}

