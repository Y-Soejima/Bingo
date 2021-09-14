using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public int num;
    public bool isOpen = false;
    [SerializeField]public Text text = null;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Open(this.gameObject);
    }

    void Open(GameObject gameObject)
    {
        var panel = GetComponent<Image>();
        if (isOpen == true)
        {
            panel.color = Color.red;
        }
        else
        {
            panel.color = Color.white;
        }
    }
}
