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

    // 繪製圖示事件：持續繪製圖示，僅在 Unity 內顯示，遊戲看不到
    private void OnDrawGizmos()
    {
        // 決定顏色
        Gizmos.color = new Color(0.8f, 0, 0.4f, 0.5f);
        // 繪製圖示形狀
        Gizmos.DrawSphere(transform.position, radiusAttack);
    }

    private void Update()
    {
        CheckAttackArea();
    }

    private void CheckAttackArea()
    {
        // 碰撞物件陣列 = 物理.球體覆蓋區域(中心點，半徑)
        Collider[] hits = Physics.OverlapSphere(transform.position, radiusAttack);
        print($"<color=#44ff00>進入攻擊區的第一個物件：{hits[0]}</color>");
    }
}
