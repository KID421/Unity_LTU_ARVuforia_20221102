using UnityEngine;

public class TowerSystem : MonoBehaviour
{
    [SerializeField, Header("要丟擲的物件")]
    private GameObject prefabFireObject;
    [SerializeField, Header("丟擲物件的力道")]
    private Vector3 powerFire = new Vector3(0, 50, 500);
    [SerializeField, Header("生成丟擲物件位置")]
    private Transform pointToSpawn;
    [SerializeField, Header("丟擲物件間隔"), Range(0, 5)]
    private float intervalFire = 3;

    [SerializeField, Header("攻擊範圍尺寸"), Range(0, 10)]
    private float radiusAttack = 5.5f;
    [SerializeField, Header("攻擊偵測圖層")]
    private LayerMask layerAttack;

    private Transform targetInAttackArea;
    private float timer;

    // 繪製圖示事件：持續繪製圖示，僅在 Unity 內顯示，遊戲看不到
    private void OnDrawGizmos()
    {
        // 決定顏色
        Gizmos.color = new Color(0.8f, 0, 0.4f, 0.5f);
        // 繪製圖示形狀
        Gizmos.DrawSphere(transform.position, radiusAttack);
    }

    private void Awake()
    {
        timer = intervalFire;
    }

    private void Update()
    {
        CheckAttackArea();
        LookAtTarget();
        FireObject();
    }

    private void CheckAttackArea()
    {
        // 如果已經有目標物 就 跳出
        if (targetInAttackArea) return;

        // 碰撞物件陣列 = 物理.球體覆蓋區域(中心點，半徑)
        Collider[] hits = Physics.OverlapSphere(transform.position, radiusAttack, layerAttack);

        // 如果 進入攻擊區的物件數量 大於 零
        if (hits.Length > 0)
        {
            print($"<color=#44ff00>進入攻擊區的第一個物件：{hits[0]}</color>");
            // 儲存第一個進入的物件為目標
            targetInAttackArea = hits[0].transform;
        }
    }

    private void LookAtTarget()
    {
        // 如果 沒有目標物 就跳出
        if (targetInAttackArea == null) return;
        // 塔.面向(目標物)
        transform.LookAt(targetInAttackArea);
    }

    private void FireObject()
    {
        // 如果 沒有目標物件 就 跳出
        if (targetInAttackArea == null) return;

        // 如果 計時器 >= 間隔時間
        if (timer >= intervalFire)
        {
            // 生成物件在手上
            Instantiate(prefabFireObject, pointToSpawn.position, Quaternion.identity);
            // 計時器歸零
            timer = 0;
        }
        else
        {
            // 否則 計時器 累加 每幀的時間
            timer += Time.deltaTime;
        }
    }
}
