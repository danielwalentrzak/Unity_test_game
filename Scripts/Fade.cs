using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    public Image img;
    [SerializeField]
    private float alpha;

    private void Start()
    {
       
       StartCoroutine(FadeIn());
       
    }
    public void FadeOutCor()
    {
        gameObject.SetActive(true);
        StartCoroutine(FadeOut());

    }
    IEnumerator FadeIn()
    {
       
        alpha = 1;
        while (alpha>0)
        {
           
            alpha -= Time.deltaTime;
            img.color = new Color(0, 0, 0, alpha);
            yield return new WaitForSeconds(0);

          
        }
        gameObject.SetActive(false);

    }
    IEnumerator FadeOut()
    {
       
        alpha = 0;
        while (alpha<1)
        {

            alpha += Time.deltaTime;
            img.color = new Color(0, 0, 0, alpha);
            yield return new WaitForSeconds(0);

        }
        
    }
}
