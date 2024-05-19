using UnityEngine;
using TMPro;

public class InvisibilityPotionPickup : MonoBehaviour
{
    public TMP_Text potionCounter;
    public static int invisPotionCounter;
    private Animator animator;

    void Start()
    {
        invisPotionCounter = 0;
        potionCounter.text = "Invisibility Potions: " + invisPotionCounter;
        animator = GetComponent<Animator>();
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
            animator.SetBool("PickedUp", true);

            PlayerInvisibility playerInvisibility = other.GetComponent<PlayerInvisibility>();
            if (playerInvisibility != null)
            {
                playerInvisibility.potionCounter = potionCounter;
            }

            potionCounter.text = "Invisibility Potions: " + invisPotionCounter;

            // play a sound effect here
            Destroy(gameObject, 0.5f);
        }
    }
}
