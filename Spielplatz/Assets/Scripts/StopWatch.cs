using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopWatch : MonoBehaviour
{

    public float timeStart;
    public Text textBox;
    bool timerActive = false;
    public Text keyText;
    public Text resetText;
    // Start is called before the first frame update
    void Start()
    {
        textBox.text = timeStart.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.K)) {
            TimerButton();
        }
        if (timerActive)
        {
            timeStart += Time.deltaTime;
            textBox.text = timeStart.ToString("F2");
            keyText.text = "Press \"K\" to stop timer";
            resetText.text = "";


        }
        else
        {
            resetText.text = "Press \"L\" to Reset the Timer";
            if (Input.GetKeyDown(KeyCode.L)) {
                timeStart = 0.00f;
                textBox.text = timeStart.ToString("F2");

                keyText.text = "Press \"K\" to start timer";
            }
            
        }
    }

    public void TimerButton()
    {
        timerActive = !timerActive;
    }
}
