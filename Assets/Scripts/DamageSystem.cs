using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace KID
{
    /// <summary>
    /// 傷害系統：儲存血量、判斷扣血與死亡
    /// </summary>
    public class DamageSystem : MonoBehaviour
    {
        [SerializeField, Header("血量"), Range(0, 5000)]
        private float hp;
        [SerializeField, Header("血條")]
        private Image imgHp;
        [SerializeField, Header("畫布血條")]
        private GameObject goCanvasHp;

        private float maxHp;
        private Animator ani;
        private string parDamage = "觸發受傷";
        private string parDead = "開關死亡";
        private NavMeshAgent nma;
        private TowerSystem towerSystem;
        private CapsuleCollider col;
        private PlayerDataSystem playerDataSystem;

        private void Awake()
        {
            ani = GetComponent<Animator>();
            nma = GetComponent<NavMeshAgent>();
            col = GetComponent<CapsuleCollider>();

            // 透過類型尋找物件<泛型>(); - 該類型只能有一個在場景上
            towerSystem = FindObjectOfType<TowerSystem>();
            playerDataSystem = FindObjectOfType<PlayerDataSystem>();

            maxHp = hp;
        }

        /// <summary>
        /// 造成傷害
        /// </summary>
        /// <param name="damage">傷害值</param>
        public void GetDamage(float damage)
        {
            hp -= damage;
            imgHp.fillAmount = hp / maxHp;
            ani.SetTrigger(parDamage);

            if (hp <= 0) Dead();
        }

        /// <summary>
        /// 死亡
        /// </summary>
        private void Dead()
        {
            ani.SetBool(parDead, true);
            nma.isStopped = true;
            gameObject.layer = 0;                   // 還原圖層
            towerSystem.targetInAttackArea = null;  // 塔系統的目標 為 空值
            col.enabled = false;                    // 碰撞器關閉
            goCanvasHp.SetActive(false);            // 畫布血條隱藏
            Destroy(gameObject, 1.5f);              // 刪除(此遊戲物件，延遲時間)
            playerDataSystem.UpdateCoin(30);
        }
    }
}
