using UnityEngine;

namespace KID
{
    /// <summary>
    /// 攻擊系統：判斷要攻擊的物件並傳遞傷害
    /// </summary>
    public class AttackSystem : MonoBehaviour
    {
        [SerializeField, Header("要攻擊的物件名稱")]
        private string nameTarget;

        //[SerializeField, Header("攻擊力"), Range(0, 5000)]
        //private float attack;

        private void OnCollisionEnter(Collision collision)
        {
            // 如果 碰到物件名稱 包含 要攻擊的物件名稱
            if (collision.gameObject.name.Contains(nameTarget))
            {
                // 碰到物件取得傷害系統 並 呼叫 造成傷害(攻擊力)
                collision.gameObject.GetComponent<DamageSystem>().GetDamage(PlayerDataSystem.attack);
            }
        }
    }
}
