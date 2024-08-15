using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum TimeSetterMethod
{
    Inspector,
    Random
}

public class UITimeSetter : MonoBehaviour
{

    public TimeSetterMethod Method;

    public TextMeshProUGUI Text;

    [Range(0,23)]
    public int Hours;

    [Range(0,59)]
    public int Minutes;

    private string _hours;
    private string _minutes;

    // Start is called before the first frame update
    void Start()
    {
        if (Method == TimeSetterMethod.Inspector)
        {
            SetText();
        }
        else
        {
            Hours = Random.Range(0, 23);
            Minutes = Random.Range(0, 59);

            //Debug.Log($"{Hours}  {Minutes}");
            SetText();
        }
    }

    private void SetText()
    {
        if (Hours >= 10)
        {
            _hours = Hours.ToString();
        }
        else
        {
            _hours = "0";
            _hours += Hours.ToString();
        }

        if (Minutes >= 10)
        {
            _minutes = Minutes.ToString();
        }
        else
        {
            _minutes = "0";
            _minutes += Minutes.ToString();
        }
        string result = _hours + ":" + _minutes;
        Text.text = result;
    }
}
