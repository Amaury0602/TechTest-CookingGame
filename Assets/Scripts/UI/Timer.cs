using System.Collections;
using UnityEngine;
using TMPro;
using DG.Tweening;

namespace WorldSpaceUI
{
    [RequireComponent(typeof(BaseEventListener))]
    public class Timer : MonoBehaviour
    {
        private TMP_Text timerText;
        [Header("Set Round Duration")]
        [SerializeField] private int countDownTime = 60;
        private int actualTimer;

        [Header("Reference to retry button")]
        [SerializeField] private GameObject retryButton;

        //Tween helpers
        private Color fontStartColor = new Color(255, 246, 0);
        private Vector3 objectInitialScale;

        [Header("Reference to Base Event")]
        [SerializeField] private BaseEvent onTimerEnd;

        private AudioSource aSource;

        private void Start()
        {
            aSource = GetComponent<AudioSource>();
        }
        
        // The timer should start after the player picks the knife
        public void StartTimer()
        {
            actualTimer = countDownTime;
            objectInitialScale = transform.localScale;
            timerText = GetComponentInChildren<TMP_Text>();
            StartCoroutine(CountDownToEnd());
        }

        private IEnumerator CountDownToEnd()
        {
            while (actualTimer > 0)
            {
                if (actualTimer <= 5)
                {
                    timerText.color = Color.red;
                    transform.DOScale(Vector3.one * 3, 0.5f)
                        .OnComplete(() => transform.DOScale(objectInitialScale, 0.5f));
                }
                else
                {
                    timerText.color = fontStartColor;
                }
                timerText.text = actualTimer.ToString();
                yield return new WaitForSeconds(1f);
                actualTimer--;
            }
            onTimerEnd.Raise();
            aSource.Play();
            timerText.text = "Finished !";

            yield return new WaitForSeconds(1f);
            retryButton.SetActive(true);
            timerText.gameObject.SetActive(false);
        }
    }
}

