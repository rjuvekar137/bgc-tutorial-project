using UnityEngine;
using TMPro;

public class InvisibilityPotionPickup : MonoBehaviour
{
    public TMP_Text potionCounter;
    public static int invisPotionCounter = 0;

    void Start()
    {
        potionCounter.text = "Invisibility Potions: " + invisPotionCounter;
    }

    void Update()
    {
        potionCounter.text = "Invisibility Potions: " + invisPotionCounter;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            invisPotionCounter++;

            // Find the PlayerInvisibility script on the player and set its potionCounter reference
            PlayerInvisibility playerInvisibility = other.GetComponent<PlayerInvisibility>();
            if (playerInvisibility != null)
            {
                playerInvisibility.potionCounter = potionCounter;
            }

            // Update the potion counter text here
            potionCounter.text = "Invisibility Potions: " + invisPotionCounter;

            // play a sound effect here
            Destroy(gameObject, 0.5f);
        }
    }
}
