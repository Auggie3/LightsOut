using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LightsOutScript : MonoBehaviour
{
    public Button[] buttons = new Button[25];
    public static Button[,] buttonsM = new Button[5,5];
    public static int[,] logika = new int[5, 5];
    public TextMeshProUGUI text = null;
    // Start is called before the first frame update
    void Start()
    {
        int brojUpaljenih = 0;
        int c = 0;
        
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                buttonsM[i, j] = buttons[i * 5 + j];
                buttonsM[i, j].GetComponent<Image>().color = Color.black;
                logika[i, j] = 0;
                c = Random.Range(0, 2);
                if (c == 1)
                {
                    buttonsM[i, j].GetComponent<Image>().color = Color.yellow;
                    logika[i, j] = 1;
                    brojUpaljenih++;
                }
            }
        }

        if (brojUpaljenih == 0)
        {
            buttonsM[2,3].GetComponent<Image>().color = Color.yellow;
            logika[2, 3] = 1;
        }
    }

    void paliGasi(int i, int j)
    {
        if (logika[i, j] == 0)
        {
            buttonsM[i, j].GetComponent<Image>().color = Color.yellow;
            logika[i, j] = 1;
        }
        else if(logika[i, j] == 1)
        {
            buttonsM[i, j].GetComponent<Image>().color = Color.black;
            logika[i, j] = 0;
        }
            
    }

    public void Klik(int x)
    {
        int i = x / 10;
        int j = x % 10;
        try
        {
            paliGasi(i, j);
        }
        catch
        {

        }
        try
        {
            paliGasi(i+1, j);
        }
        catch
        {

        }
        try
        {
            paliGasi(i-1, j);
        }
        catch
        {

        }
        try
        {
            paliGasi(i, j+1);
        }
        catch
        {

        }
        try
        {
            paliGasi(i, j-1);
        }
        catch
        {

        }

        if (Kraj() == 1) text.text= "YOU WON!";
        else
        {
            text.text = "";
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        Start();
    }

    int Kraj()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (logika[i, j] == 1) return 0;
            }
        }

        return 1;
    }

}
