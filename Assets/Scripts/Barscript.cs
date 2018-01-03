using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Barscript : MonoBehaviour {

    private float fillamount;

    [SerializeField]
    private float barspeed;

    [SerializeField]
    private Image content;

    [SerializeField]
    private Text val;
    [SerializeField]
    private Color full;
    [SerializeField]
    private Color low;

    public float MaxValue { get; set; }
    
    public float Value
    {
        set
        {
            string[] tmp = val.text.Split(':');
            val.text = tmp[0] + ": " + value;
            fillamount = map(value, 0, MaxValue, 0, 1);
        }
    }


	void Start ()
    {
		
	}
	

	void Update ()
    {
        handlebar();
    }

    private void handlebar()
    {
        if(fillamount != content.fillAmount)
        {
            
            content.fillAmount = Mathf.Lerp(content.fillAmount, fillamount, Time.deltaTime * barspeed);
        }

        content.color = Color.Lerp(low, full, fillamount);
    }

    private float map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }

}
