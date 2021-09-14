using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpen : MonoBehaviour
{
    Panel panel;
    private int[] randomNum = new int[75];
    private int randomNumIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        panel = FindObjectOfType<Panel>();
        for (int i = 1; i <= randomNum.Length; i++)
        {
            randomNum[i - 1] = i;
        }
        for (int i = 0; i < 100000; i++)
        {
            int a = Random.Range(0, randomNum.Length);
            int b = Random.Range(0, randomNum.Length);
            int c = randomNum[a];
            randomNum[a] = randomNum[b];
            randomNum[b] = c;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        Debug.Log(randomNum[randomNumIndex]);
        panel.numChack(randomNum[randomNumIndex]);
        randomNumIndex++;
    }
}
