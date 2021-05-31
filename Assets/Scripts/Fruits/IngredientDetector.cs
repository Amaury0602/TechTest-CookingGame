using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Fruit 
{
    [RequireComponent(typeof(AudioSource))]
    public class IngredientDetector : MonoBehaviour
    {
        [Header("Select the fruit that shall receive this pot")]
        [SerializeField] private SlicedFruit.Type fruitToReceive;

        [Header("Events to raise when fruit is received")]
        [SerializeField] private IntEvent onFruitReceived;
        [SerializeField] private LocalEvent onGoodFruitReceived;

        [SerializeField] private GameObject steamEffect;

        private AudioSource aSource;

        private bool isAcceptingFruits = false;

        private List<GameObject> fruitsInPot = new List<GameObject>();

        /// <summary>
        /// This code allows us to send the right event to the UI
        /// Code 0 corresponds to Apple
        /// Code 1 corresponds to Avocado
        /// </summary>
        private int fruitIntCode;

        private void Start()
        {
            aSource = GetComponent<AudioSource>();
            aSource.volume = 0;
            fruitIntCode = fruitToReceive == SlicedFruit.Type.Apple ? 0 : 1;
        }

        // Start is called before the first frame update
        private void OnTriggerEnter(Collider other)
        {
            if (!isAcceptingFruits) return;
            if (other.GetComponent<SlicedFruit>() != null)
            {
                SlicedFruit fruit = other.GetComponent<SlicedFruit>();
                if (fruit.type == fruitToReceive && !fruit.alreadyCounted)
                {
                    fruit.CountInPot();
                    onFruitReceived.Raise(fruitIntCode);
                    onGoodFruitReceived.Raise(other.transform.position);
                    fruitsInPot.Add(other.gameObject);
                }
            }
        }

        public void ShouldDetectFruit(bool startDetect)
        {
            if (steamEffect != null) steamEffect.SetActive(startDetect);
            isAcceptingFruits = startDetect;
            if (startDetect)
            {
                aSource.Play();
                DOTween.To(() => aSource.volume, x => aSource.volume = x, 0.1f, 1f);
            }
            else
            {
                DOTween.To(() => aSource.volume, x => aSource.volume = x, 0, 1f).OnComplete(() => aSource.Stop());
                aSource.Stop();
            }
        }

        public void EmptyPot()
        {
            foreach (GameObject fruit in fruitsInPot)
            {
                if (fruit != null) Destroy(fruit);
            }
        }
    }
}

