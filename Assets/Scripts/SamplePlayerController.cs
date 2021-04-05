using UnityEngine;
using UnityEngine.SceneManagement;

// Playerの移動操作
public class SamplePlayerController : MonoBehaviour
{
    // Playerの移動に関する変数群
    Transform _transfrom;
    Rigidbody _rigidbody;
    Vector3 _inputVector;      // 入力値
    Vector3 _velocity;         // 前方方向の加速度
    [SerializeField]
    float _moveSpeed = 2.0f;   // 移動速度


    void Awake()
    {
        // 変数の取得
        _transfrom = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 速度の初期化
        _velocity = Vector3.zero;
        // A, D, 左右の矢印キー
        float hor = Input.GetAxis("Horizontal");
        // W, S, 上下の矢印キー
        float ver = Input.GetAxis("Vertical");
        // 入力値を代入
        _inputVector = new Vector3(hor, 0, ver);
    }

    void FixedUpdate()
    {
        if(_inputVector.sqrMagnitude > 0)
        {
            // 移動方向の決定
            transform.LookAt(transform.position + _inputVector.normalized);
            if(_inputVector.magnitude > 0.1f)
            {
                _velocity += transform.forward * _moveSpeed;
                _rigidbody.velocity = _velocity;
            }
        }
    }
}
