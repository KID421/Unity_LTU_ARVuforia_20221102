using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    #region 資料
    // #region 程式碼片段快捷鍵：Ctrl + K X > Visual C# > #region

    // 欄位屬性 Field Property：欄位資料額外輔助功能
    // SerializeField 序列化欄位，將私人資料儲存於記憶體並顯示
    // Header 標題：顯示標題訊息於屬性面板
    // Range 範圍：限制數值的範圍 (float 或 int)

    // 預製物可以使用 GameObject 資料類型
    [SerializeField, Header("怪物預製物")]
    private GameObject prefabEnemy;

    // 浮點數 float 帶有小數點的正負數值，必須加 f 或 F
    [SerializeField, Header("生成怪物間隔"), Range(0, 5)]
    private float spawnInterval = 2.5f;

    // 存放座標資料類型 Transrofm
    // 資料類型[] - 陣列：存放多筆資料
    [SerializeField, Header("怪物生成點陣列")]
    private Transform[] spawnPoints;
    #endregion

    // 喚醒事件：播放遊戲時執行一次
    private void Awake()
    {
        // 呼叫生成敵人方法
        // SpawnEnemy();

        // 重複延遲呼叫(方法名稱，延遲時間，重複頻率)
        InvokeRepeating("SpawnEnemy", 0, spawnInterval);
    }

    private void SpawnEnemy()
    {
        // 隨機取得一個怪物生成點
        // 隨機整數 = 隨機.範圍(最小值，最大值) 整數不會等於最大值
        int random = Random.Range(0, spawnPoints.Length);
        // print("隨機值：" + random);

        // 生成(物件，隨機生成點的座標，隨機生成點的角度)；
        Instantiate(
            prefabEnemy, 
            spawnPoints[random].position, 
            spawnPoints[random].rotation);
    }
}
