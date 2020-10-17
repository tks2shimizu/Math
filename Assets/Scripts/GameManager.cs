using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private enum Type
    {
        Type1,
        Type2,
        Type3,
    }

    [SerializeField]
    private Type type = Type.Type1;
    private GameObject _sumomo;
    private Vector3 _sumomoStartPosition;
    private Vector3 _position = new Vector3(0, 0, 0);
    private const float Range = 150f;

    void Start()
    {
        _sumomo = GameObject.Find("Sumomo");
        _sumomoStartPosition = _sumomo.transform.position;
    }

    public void PointDownSumomo()
    {
        _position = Input.mousePosition;
    }
    
    public void DragSumomo()
    {
        var diff = _position - Input.mousePosition;

        _sumomo.transform.position -= diff;

        if (type == Type.Type2)
        {
            //your code
        }
        else if (type == Type.Type3)
        {
            //your code
        }
        
        _position = Input.mousePosition;
    }
}
