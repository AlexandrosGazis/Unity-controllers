using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionPickUp : MonoBehaviour
{

    public int QuestionsValue;

    public GameObject pickupQuestionEffect;


    // Start is called before the first frame update
    void Start()
    {

        //Destroy(gameObject, GetComponent<ParticleSystem>().main.duration);


    }

    // Update is called once per frame
    void Update()
    {

    }

    //on Trigger--> when another collider touches this trigger area do:
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") //check if player is on the area--> if the colliding object has the tag: "Player" 
        {
            FindObjectOfType<GameManagerScoreRespawn>().AddQuestion(QuestionsValue);

            // Instantiate(pickupQuestionEffect, transform.position, transform.rotation);//create a copy of the referenced object, i.e. show the effect with the particles
            //Destroy(pickupQuestionEffect, 3f);//destroy the question that was used
            // Destroy(gameObject);//destroy the question that was used
            //Destroy(gameObject, GetComponent<ParticleSystem>().main.duration);
            
            GameObject effect = Instantiate(pickupQuestionEffect, transform.position, transform.rotation);
            Destroy(effect, 1.2f);//destroy particle effect 
            Destroy(gameObject);//destroy the question that was used
        }
    }
}
