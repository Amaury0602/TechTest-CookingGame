using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EffectHandler : MonoBehaviour
{
    [SerializeField] private EffectAsset effect;

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayEffect(Vector3 effectPosition)
    {
        effect.PlayEffect(source, effectPosition);
    }
}
