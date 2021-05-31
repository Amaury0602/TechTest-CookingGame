using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

namespace WorldSpaceUI
{
    [RequireComponent(typeof(IntEventListener))]
    public class FruitCounterUI : MonoBehaviour
    {
        /// <summary>
        /// fruitCounters tracks the number of apples and avocados
        /// the first integer represents the fruit code (0 = apple and 1 = avocado)
        /// the second integer represents the number of fruits counted
        /// </summary>
        private Dictionary<int, int> fruitCounters = new Dictionary<int, int>();

        private TMP_Text[] counterTexts;
        private float initialFontSize;

        [Header("Tween Parameters")]
        [SerializeField] private float fontScaleDuration = 0.3f;

        void Start()
        {
            counterTexts = GetComponentsInChildren<TMP_Text>();
            counterTexts[0].text = "Apples :";
            counterTexts[1].text = "Avocados :";

            initialFontSize = counterTexts[0].fontSize;

            fruitCounters.Add(0, 0);
            fruitCounters.Add(1, 0);
        }

        public void UpdateCounter(int fruitCode)
        {
            fruitCounters[fruitCode]++;
            string fruitName = fruitCode == 0 ? "Apples : " : "Avocados : ";
            counterTexts[fruitCode].text = fruitName + fruitCounters[fruitCode].ToString();
            counterTexts[fruitCode].fontSize = 0;
            DOTween.To(() => counterTexts[fruitCode].fontSize, x => counterTexts[fruitCode].fontSize = x, initialFontSize, fontScaleDuration)
                .SetEase(Ease.OutQuad);
        }

        /// <summary>
        /// RetryCounter is called when the player hits the "Retry" button
        /// </summary>
        public void ResetCounters()
        {
            fruitCounters[0] = 0;
            fruitCounters[1] = 0;
            counterTexts[0].text = "Apples :";
            counterTexts[1].text = "Avocados :";
        }
    }
}

