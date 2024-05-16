using System.Collections;
using TMPro;
using UnityEngine;

public class InvisibilityPotionPickup : MonoBehaviour
{
    //public AudioClip lootSFX;
    public TMP_Text potionCounter;
    public TMP_Text instructions;
    public static bool isInvisible;
    int invisPotionCounter = 0;

    void Start()
    {
        potionCounter.text = "Invisibility Potions: 0";
        instructions.text = "To enable invisibility, press space!";
        isInvisible = false;
    }

    void Update()
    {
        Debug.Log("Update method is running");
        if (invisPotionCounter > 0 && !isInvisible)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                print("Space key pressed");
                StartCoroutine(ActivateInvisibility());
            }
        }
    }

    IEnumerator ActivateInvisibility()
    {
        isInvisible = true;
        print("ur invis");
        invisPotionCounter--;
        potionCounter.text = "Invisibility Potions: " + invisPotionCounter;
        instructions.text = "You're invisible! Run!";

        yield return new WaitForSeconds(5f);

        isInvisible = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            invisPotionCounter++;
            potionCounter.text = "Invisibility Potions: " + invisPotionCounter;
            //AudioSource.PlayClipAtPoint(lootSFX, transform.position);
            print(invisPotionCounter);

            Destroy(gameObject, 0.5f);
        }
    }
}
