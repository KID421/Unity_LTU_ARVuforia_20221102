using UnityEngine;
using UnityEngine.AI;

public class TrackSystem : MonoBehaviour
{
    [SerializeField, Header("追蹤速度"), Range(0, 5)]
    private float speed = 2;
    [SerializeField, Header("停止距離"), Range(0, 10)]
    private float stoppintDistance = 5;

    private string nameTarget = "屁孩";
    private Transform pointTarget;
    private NavMeshAgent nma;

    private void Awake()
    {
        // 目標物件的座標資訊 = 遊戲物件.尋找(目標物名稱) 轉型為變形
        pointTarget = GameObject.Find(nameTarget).transform;
    }
}
