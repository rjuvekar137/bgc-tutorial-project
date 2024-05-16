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
            potionCounter.text = "Invisibility Potions: " + invisPotionCounter;
            // play a sound effect here
            Destroy(gameObject, 0.5f);
        }
    }
}
