using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBars : MonoBehaviour
{
    
    public Image czerwony;
    public Image bialy;
    private Slider bialyslider;
    private Slider czerwonyslider;
    [SerializeField] private float hp;
    [SerializeField] private float maxhp;
    [SerializeField] private float fillspeed = 0.001f;
    void Start()
    {

        hp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovment>().hp;
        maxhp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovment>().maxhp;
        czerwonyslider = bialy.GetComponent<Slider>();
        bialyslider = czerwony.GetComponent<Slider>();
        bialyslider.maxValue = 1;
        bialyslider.value = hp;
        czerwonyslider.maxValue = 1;
        czerwonyslider.value = hp;
    }

    // Update is called once per frame
    void Update()
    {
        hp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovment>().hp;
        czerwonyslider.value = hp/maxhp;
          if (czerwonyslider.value < bialyslider.value)
          {
            gameObject.GetComponent<Animation>().Play("test");
            bialyslider.value -= fillspeed;
          }
          else if (czerwonyslider.value > bialyslider.value)
          {
            bialyslider.value= czerwonyslider.value;
        }
      
    }
}
