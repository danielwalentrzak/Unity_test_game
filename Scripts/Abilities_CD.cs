using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities_CD : MonoBehaviour
{
    [SerializeField] private GameObject grayedfireball;
    public Image fireballability;
    public float fireballcd;
    public float fireballcdmax;
    public float dashcd;
    public float dashcdmax;
    public Image dash;
    // Start is called before the first frame update
    void Start()
    {
  
        fireballability.fillAmount = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player_attack>().hasabilility == false)
        {
            grayedfireball.SetActive(true);
        }
        else
            grayedfireball.SetActive(false);
        fireballcdmax = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_attack>().cooldownmax;
        fireballcd = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_attack>().cooldown;
        fireballability.fillAmount = 1 - fireballcd / fireballcdmax;
        if (fireballability.fillAmount != 1)
        {
            fireballability.color=new Color32(97,97,97,255);
        }
        else
         fireballability.color = new Color(255, 255, 255);
        dashcdmax = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovment>().dashcdmax;
        dashcd = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovment>().dashcd;
        dash.fillAmount = 1 - dashcd / dashcdmax;
        if (dash.fillAmount != 1)
        {
            dash.color = new Color32(97, 97, 97, 255);
        }
        else
            dash.color = new Color32(207, 162, 255,255);


    }
}
