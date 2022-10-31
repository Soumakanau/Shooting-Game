using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Vector2 rawInput;

    //プレイヤーが動ける範囲
    [SerializeField] float _paddingLeft;
    [SerializeField] float _paddingRight;
    [SerializeField] float _paddingTop;
    [SerializeField] float _paddingBottom;

    Vector2 _minBounds;
    Vector2 _maxBounds;

     void Start()
    {
        InitBounds();
    }

    void Update()
    {
        Move();
    }

    //プレイヤーがカメラの外に行かないように
    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        _minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        _maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }
     //プレイヤーの移動
    void Move()
    {
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, _minBounds.x + _paddingLeft, _maxBounds.x - _paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, _minBounds.y + _paddingBottom, _maxBounds.y - _paddingTop);
        transform.position = newPos;

    }
    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
        Debug.Log(rawInput);
    }
}
