using UnityEngine;

/// <summary>
/// Event asset, useful when you need to instantiate a special effect associated with sound 
/// at a specific location.
/// </summary>

[CreateAssetMenu(fileName = "New Effect Asset", menuName = "ScriptableObject/Effect")]
public class EffectAsset : ScriptableObject
{
    [SerializeField] private GameObject visualEffect;
    [SerializeField] private AudioClip[] soundClips;
    [SerializeField] private float effectDuration = 1f;

    public void PlayEffect(AudioSource source, Vector3 position)
    {
        if (visualEffect)
        {
            GameObject newEffect = Instantiate(visualEffect, position, Quaternion.identity);
            Destroy(newEffect, effectDuration);
        }
        if (soundClips.Length > 0)
        {
            source.clip = soundClips[Random.Range(0, soundClips.Length)];
            source.Play();
        }
    }
}
