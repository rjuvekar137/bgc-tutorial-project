using System.Collections;
using UnityEngine;
using TMPro;

public class InvisibilityPotionPickup : MonoBehaviour
{
    public TMP_Text potionCounter;
    public static int invisPotionCounter;
    public AudioSource pickupAudio;
    private Animator animator;
    private bool isPickedUp = false;

    void Start()
    {
        invisPotionCounter = 0;
        potionCounter.text = "Invisibility Potions: " + invisPotionCounter;
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found!");
        }
    }

    void Update()
    {
        potionCounter.text = "Invisibility Potions: " + invisPotionCounter;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isPickedUp)
        {
            isPickedUp = true;
            invisPotionCounter++;
            //Debug.Log("Invisibility Potion picked up. Counter: " + invisPotionCounter);

            animator.SetBool("PickedUp", true);
            //Debug.Log("PickedUp set to true in Animator.");

            PlayerInvisibility playerInvisibility = other.GetComponent<PlayerInvisibility>();
            if (playerInvisibility != null)
            {
                playerInvisibility.potionCounter = potionCounter;
            }

            potionCounter.text = "Invisibility Potions: " + invisPotionCounter;

            pickupAudio.Play();
            animator.SetBool("PickedUp", true);
            Destroy(gameObject, 3.0f);
        }
    }
}
