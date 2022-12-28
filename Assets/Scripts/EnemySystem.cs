using UnityEngine;

namespace KID
{
    /// <summary>
    /// 敵人系統：偵測目標物並造成傷害
    /// </summary>
    public class EnemySystem : MonoBehaviour
    {
        [SerializeField, Header("攻擊力"), Range(0, 1000)]
        private float attack = 50;
        [SerializeField, Header("攻擊距離"), Range(0, 10)]
        private float attackDistance = 3.5f;
        [SerializeField, Header("攻擊冷卻時間"), Range(0, 5)]
        private float attackInterval = 3;

        private string nameTarget = "屁孩";
        private Transform pointTarget;
        private PlayerDataSystem playerDataSystem;
        private Animator ani;
        private string parAttack = "觸發攻擊";
        private float attackTimer;

        private void Awake()
        {
            attackTimer = attackInterval;
            ani = GetComponent<Animator>();
            pointTarget = GameObject.Find(nameTarget).transform;
            playerDataSystem = pointTarget.GetComponent<PlayerDataSystem>();
        }

        private void Update()
        {
            Attack();
        }

        /// <summary>
        /// 攻擊
        /// </summary>
        private void Attack()
        {
            float dis = Vector3.Distance(transform.position, pointTarget.position);

            if (dis <= attackDistance)
            {
                if (attackTimer >= attackInterval)
                {
                    ani.SetTrigger(parAttack);
                    attackTimer = 0;
                    playerDataSystem.GetDamage(attack);
                }
                else
                {
                    attackTimer += Time.deltaTime;
                }
            }
        }
    }
}
