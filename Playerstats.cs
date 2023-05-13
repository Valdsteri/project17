using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Playerstats : MonoBehaviour
{
    public Text healthtext;
    public float health = 100f;
    public GameObject Deathscreen;
    public bool isBeingAttacked = false;

    //scripts
    public PickUpAK Pickupscript;

    void Start ()
    {
        health = 100f;
        isBeingAttacked = false;
        Debug.Log("Startin and put" + isBeingAttacked);
        
    }


    void Update ()
    {
        healthtext.text = health.ToString();
        if (health <= 0f)
        {
            isBeingAttacked = false;
            Deathscreen.SetActive(true);
            Invoke("deathshii", 3f);
            GameObject.Find("MainCamera").GetComponent<MouseLook>().enabled = false;
            GameObject.Find("Player").GetComponent<Playermovement>().enabled = false;
            Pickupscript.Drop();
        }
    }

    public IEnumerator TakeDamage(float damage)
    {
        Debug.Log(isBeingAttacked);
        if (!isBeingAttacked)
        {
            isBeingAttacked = true;
            Debug.Log("Taking damage");
            
            health -= damage;
            Debug.Log(health);

            float timer = 0f;
            while (timer < 2f) // Wait for 2 seconds
            {
                timer += Time.deltaTime;
                yield return null;
                Debug.Log("in timer");
            }
            Debug.Log("after timer, turning to false");
            isBeingAttacked = false;
            Debug.Log("after timer, should be false =" + isBeingAttacked);
        }
    }

    




    void deathshii ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }
}
