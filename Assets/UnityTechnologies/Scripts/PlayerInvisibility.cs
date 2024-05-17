using System.Collections;
using UnityEngine;
using TMPro;

public class PlayerInvisibility : MonoBehaviour
{
    public TMP_Text instructions;
    public TMP_Text potionCounter;
    public static bool isInvisible;

    void Start()
    {
        instructions.text = "To enable invisibility, press space!";
        isInvisible = false;
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
        isInvisible = true;
        InvisibilityPotionPickup.invisPotionCounter--;
        instructions.text = "You're invisible! Run!";

        // Update the potion counter text here
        potionCounter.text = "Invisibility Potions: " + InvisibilityPotionPickup.invisPotionCounter;

        yield return new WaitForSeconds(5f);

        isInvisible = false;
        instructions.text = "To enable invisibility, press space!";
    }
}
