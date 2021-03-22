using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text npcname;
    public Text  npcdial;
    private Queue<string> sentences; //FIFO first in first out
    public GameObject buttons_levelup_ab;
    public GameObject ab_Up;
    public GameObject ab_cd_up;
    public GameObject buttons_levelups;
    public GameObject dash_up;
    public GameObject next_button;
    // Update is called once per frame
    void Start()
    {
        sentences = new Queue<string>();
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player_attack>().hasabilility == false) { 
        ab_Up.GetComponentInChildren<Text>().text = "Odblokuj umiejętność";
        ab_cd_up.GetComponentInChildren<Text>().text = "Odblokuj umiejętność";
        }
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player_attack>().hasabilility == true && GameObject.FindGameObjectWithTag("Player").GetComponent<Player_attack>().hasautoaim == false)
            ab_cd_up.GetComponentInChildren<Text>().text = "Odblokuj namierzanie";
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovment>().upgradeddash == false)
        {
            dash_up.GetComponentInChildren<Text>().text = "Odblokuj Dash mk.II";
        }
    }
    public void StartDialogue(Dialogue dial, bool activ)
    {
        if(activ == true)
        {
            EndDial(dial);
            return;
        }
        npcname.text = dial.name;
        sentences.Clear();
        foreach(string sent in dial.dialog)
        {
            sentences.Enqueue(sent);
        }
        NextSent();
    }

    public void NextSent()
    {
        if (sentences.Count == 0 && FindObjectOfType<NPC>().activated == false)
        {
            if(npcname.text == "Kajito")
            buttons_levelups.SetActive(true);
            if (npcname.text == "Shark")
                buttons_levelup_ab.SetActive(true);
            return;
        }
       string sen=sentences.Dequeue();
        npcdial.text = sen;
    }
    public void Attup()
    {
        
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player_attack>().dmg += 10;
        buttons_levelups.SetActive(false);
        foreach (NPC a in FindObjectsOfType<NPC>())
            a.activated = true;
        EndDial();
    }
    public void Dashup()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovment>().upgradeddash == false)
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovment>().upgradeddash = true;
        else
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovment>().dashcdmax -= 0.5f;
        buttons_levelups.SetActive(false);
        foreach (NPC a in FindObjectsOfType<NPC>())
            a.activated = true;
        EndDial();
    }
    public void Abup()
    {

       
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player_attack>().hasabilility == true)
        {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player_attack>().ability += 10;
        }
        else
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_attack>().hasabilility = true;
        buttons_levelup_ab.SetActive(false);

        foreach (NPC a in FindObjectsOfType<NPC>())
            a.activated = true;
   
        EndDial();
    }

    public void Cdup()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player_attack>().hasabilility == true)
        {

            if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player_attack>().hasautoaim == true)
            {
                if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player_attack>().cooldownmax > 1)
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Player_attack>().cooldownmax -= 1;
                else
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Player_attack>().ability += 10;
            }
            else
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player_attack>().hasautoaim = true;
        }
        else
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_attack>().hasabilility = true;
        buttons_levelup_ab.SetActive(false);
        foreach (NPC a in FindObjectsOfType<NPC>())
            a.activated = true;
        EndDial();
    }
    void EndDial(Dialogue dial)
    {
        next_button.SetActive(false);
        npcname.text = dial.name;
        npcdial.text = "Good luck pal";
    }
    void EndDial()
    {
        next_button.SetActive(false);
        npcdial.text = "Good luck pal";
    }
}
