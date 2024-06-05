using System.Collections;
using UnityEngine;
using TMPro;

public class PlayerInvisibility : MonoBehaviour
{
    public TMP_Text instructions;
    public TMP_Text potionCounter;
    public ParticleSystem invisibilityParticles;
    public AudioSource usePotionAudio;
    public static bool isInvisible;
    public float invisibilityDuration = 5f;

    void Start()
    {
        instructions.text = "To enable invisibility, press space!";
        isInvisible = false;
        invisibilityParticles.Stop();
    }
    
    void Update()
    {
        if (InvisibilityPotionPickup.invisPotionCounter > 0 && !isInvisible)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(ActivateInvisibility());
            }
        }
    }

    IEnumerator ActivateInvisibility()
    {
        usePotionAudio.Play();
        isInvisible = true;
        InvisibilityPotionPickup.invisPotionCounter--;
        potionCounter.text = "Invisibility Potions: " + InvisibilityPotionPickup.invisPotionCounter;
        invisibilityParticles.Play();

        float remainingTime = invisibilityDuration;
        while (remainingTime > 0)
        {
            instructions.text = $"You're invisible! Run! {remainingTime:F1} seconds left";
            yield return new WaitForSeconds(0.1f);
            remainingTime -= 0.1f;
        }

        isInvisible = false;
        instructions.text = "To enable invisibility, press space!";
        invisibilityParticles.Stop();
    }
}
