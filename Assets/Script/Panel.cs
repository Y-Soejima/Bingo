using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    private int[] randomNum = new int[75];
    private int randomNumIndex = 0;
    [SerializeField] int bingoLength;
    [SerializeField] Cell cellPrefab;
    [SerializeField] GridLayoutGroup panel;
    Cell[,] cellArray;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= randomNum.Length; i++)
        {
            randomNum[i - 1] = i;
        }
        for (int i = 0; i < 500; i++)
        {
            int a = Random.Range(0, randomNum.Length);
            int b = Random.Range(0, randomNum.Length);
            int c = randomNum[a];
            randomNum[a] = randomNum[b];
            randomNum[b] = c;
        }
        cellArray = new Cell[bingoLength, bingoLength];
        panel.constraintCount = bingoLength;
        for (int i = 0; i < bingoLength; i++)
        {
            for (int k = 0; k < bingoLength; k++)
            {
                var cell = Instantiate(cellPrefab);
                cell.transform.SetParent(panel.transform);
                cellArray[i, k] = cell;
                cellArray[i, k].num = randomNum[randomNumIndex];
                cellArray[i, k].text.text = cellArray[i, k].num.ToString();
                if (i == bingoLength / 2 && k == bingoLength / 2)
                {
                    cellArray[i, k].text.text = "";
                    cellArray[i, k].isOpen = true;
                }
                randomNumIndex++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void numChack(int value)
    {
        for (int i = 0; i < bingoLength; i++)
        {
            for (int k = 0; k < bingoLength; k++)
            {
                if (cellArray[i, k].num == value)
                {
                    cellArray[i, k].isOpen = true;
                }
            }
        }
        int reachNum = 0;
        for (int i = 0; i < bingoLength; i++)
        {
            int openNum = 0;
            for (int k = 0; k < bingoLength; k++)
            {
                if (cellArray[i, k].isOpen == true)
                {
                    openNum++;
                }
                if (k == bingoLength - 1)
                {
                    if (openNum == bingoLength - 1)
                    {
                        reachNum++;
                    }
                    if (openNum == bingoLength)
                    {
                        Debug.Log("Bingo");
                        break;
                    }
                }
                
            }
        }

        for (int i = 0; i < bingoLength; i++)
        {
            int openNum = 0;
            for (int k = 0; k < bingoLength; k++)
            {
                if (cellArray[k, i].isOpen == true)
                {
                    openNum++;
                }
                if (k == bingoLength - 1)
                {
                    if (openNum == bingoLength - 1)
                    {
                        reachNum++;
                    }
                    if (openNum == bingoLength)
                    {
                        Debug.Log("Bingo");
                        break;
                    }
                }
            }
        }
        int skewOpenNum = 0;
        for (int i = 0; i < bingoLength; i++)
        {
            
            if (cellArray[i, i].isOpen == true)
            {
                skewOpenNum++;
            }
            if (i == bingoLength - 1)
            {
                if (skewOpenNum == bingoLength - 1)
                {
                    reachNum++;
                }
                if (skewOpenNum == bingoLength)
                {
                    Debug.Log("Bingo");
                    break;
                }
            }
        }
        int returnSkewOpenNum = 0;
        for (int i = 0; i < bingoLength; i++)
        {
            if (cellArray[i, bingoLength - 1 - i].isOpen == true)
            {
                returnSkewOpenNum++;
            }
            if (i == bingoLength - 1)
            {
                if (returnSkewOpenNum == bingoLength - 1)
                {
                    reachNum++;
                }
                if (returnSkewOpenNum == bingoLength)
                {
                    Debug.Log("Bingo");
                    break;
                }
            }
        }
        Debug.Log($"{reachNum}リーチ");
    }
}
