using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeChemical3 : MonoBehaviour
{
    public GameObject itemDown;
    public GameObject itemUp;
    public Vector3 mouse;
    public Collider2D colliderChemical;

    public bool winCondition = false;

    //Sounds
    public AudioClip take;
    public AudioClip left;
    public AudioClip correct;

    public bool bcorrect;
    public bool btake;
    public bool bleft;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        bcorrect = true;
        btake = true;
        bleft = true;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        Debug.Log("xD");
        itemDown.SetActive(false);
        itemUp.SetActive(true);

        if(btake==true)
        {
            audio.PlayOneShot(take, 0.8f);
            btake = false;
        }
        bleft = true;
        
    }

    private void OnMouseDrag()
    {
        colliderChemical.enabled = false;
        mouse = Input.mousePosition;
        mouse.z = 20;
        Vector3 pos = Camera.main.ScreenToWorldPoint(mouse);
        Vector3 finalPos = new Vector3(pos.x - colliderChemical.offset.x, pos.y - colliderChemical.offset.y, 0.0f);
        transform.position = finalPos;

    }

    private void OnMouseUp()
    {
        colliderChemical.enabled = true;
        Debug.Log("xD");
        itemDown.SetActive(true);
        itemUp.SetActive(false);
        audio.PlayOneShot(left, 0.8f);
        btake = true;

        if(bleft==true)
        {
            audio.PlayOneShot(left, 0.4f);
            bleft = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag=="Chemical")
        {
            Debug.Log("JAJASJSAJSAJ");
            if (tag=="purple")
            {
                if (collision.GetComponent<Lab_WinCondition>().purpleType == false && collision.GetComponent<Lab_WinCondition>().greenType == false)
                {
                    collision.GetComponent<Lab_WinCondition>().purpleType = true;
                    collision.GetComponent<Lab_WinCondition>().puntosActuales += 0.5f;

                    if (bcorrect == true)
                    {
                        StartCoroutine(DisableTube());
                        bcorrect = false;

                    }
                }
                else if (collision.GetComponent<Lab_WinCondition>().purpleType == true && collision.GetComponent<Lab_WinCondition>().greenType == false)
                {
                    collision.GetComponent<Lab_WinCondition>().puntosActuales += 0.5f;

                    if (bcorrect == true)
                    {
                        StartCoroutine(DisableTube());
                        bcorrect = false;

                    }
                }
            }
            else if(tag=="green")
            {
                if (collision.GetComponent<Lab_WinCondition>().greenType == false && collision.GetComponent<Lab_WinCondition>().purpleType == false)
                {
                    collision.GetComponent<Lab_WinCondition>().greenType = true;
                    collision.GetComponent<Lab_WinCondition>().puntosActuales += 0.5f;

                    if (bcorrect == true)
                    {
                        StartCoroutine(DisableTube());
                        bcorrect = false;

                    }
                }else if (collision.GetComponent<Lab_WinCondition>().greenType == true && collision.GetComponent<Lab_WinCondition>().purpleType == false)
                {
                    collision.GetComponent<Lab_WinCondition>().greenType = true;
                    collision.GetComponent<Lab_WinCondition>().puntosActuales += 0.5f;

                    if (bcorrect == true)
                    {
                        StartCoroutine(DisableTube());
                        bcorrect = false;

                    }
                }
            }
            
            
            
        }
    }

    IEnumerator DisableTube()
    {
        itemDown.GetComponent<SpriteRenderer>().enabled = false;
        itemUp.GetComponent<SpriteRenderer>().enabled = false;
        audio.PlayOneShot(correct, 0.4f);
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}

