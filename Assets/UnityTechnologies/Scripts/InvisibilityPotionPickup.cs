using System.Collections;
using UnityEngine;
using TMPro;

public class InvisibilityPotionPickup : MonoBehaviour
{
    public TMP_Text potionCounter;
    public static int invisPotionCounter;
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
            Debug.Log("Invisibility Potion picked up. Counter: " + invisPotionCounter);

            animator.SetBool("PickedUp", true);
            Debug.Log("PickedUp set to true in Animator.");

            PlayerInvisibility playerInvisibility = other.GetComponent<PlayerInvisibility>();
            if (playerInvisibility != null)
            {
                playerInvisibility.potionCounter = potionCounter;
            }

            potionCounter.text = "Invisibility Potions: " + invisPotionCounter;

            // play a sound effect here
            StartCoroutine(WaitForAnimation());
        }
    }

    private IEnumerator WaitForAnimation()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        while (stateInfo.IsName("YourAnimationStateName") && stateInfo.normalizedTime < 1.0f)
        {
            yield return null;
            stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        }

        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
