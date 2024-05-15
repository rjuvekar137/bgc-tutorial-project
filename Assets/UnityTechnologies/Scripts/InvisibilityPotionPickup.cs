using TMPro;
using UnityEngine;

public class InvisibilityPotionPickup : MonoBehaviour
{
    //public AudioClip lootSFX;
    public TMP_Text potionCounter; // Use TMP_Text instead of Text
    int invisPotionCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        potionCounter.text = "Invisibility Potions: 0";
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(Vector3.forward, 90 * Time.deltaTime);

        //if (transform.position.y < Random.Range(4.0f, 7.0f))
        //{
        //    Destroy(gameObject.GetComponent<Rigidbody>());
        //}

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
