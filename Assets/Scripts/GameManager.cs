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
            _sumomo.transform.position = new Vector2(
                Mathf.Clamp(_sumomo.transform.position.x, _sumomoStartPosition.x - Range, _sumomoStartPosition.x + Range),
                Mathf.Clamp(_sumomo.transform.position.y, _sumomoStartPosition.y - Range, _sumomoStartPosition.y + Range));
        }
        else if (type == Type.Type3)
        {
            var length = Vector3.Distance(_sumomoStartPosition, _sumomo.transform.position);
            if (length > Range)
            {
                //Case:1
                _sumomo.transform.position = new Vector2(
                    _sumomoStartPosition.x + (_sumomo.transform.position.x - _sumomoStartPosition.x) * Range / length,
                    _sumomoStartPosition.y + (_sumomo.transform.position.y - _sumomoStartPosition.y) * Range / length);

                //Case:2
                // var sumomoDiff = _sumomo.transform.position - _sumomoStartPosition;
                // var rad = Mathf.Atan2(sumomoDiff.y, sumomoDiff.x);
                //
                // _sumomo.transform.position = new Vector2(
                //     _sumomoStartPosition.x + Mathf.Cos(rad) * Range,
                //     _sumomoStartPosition.y + Mathf.Sin(rad) * Range);
            }
        }
        
        _position = Input.mousePosition;
    }
}
