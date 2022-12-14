using UnityEngine;
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

        private float maxHp;
        private Animator ani;
        private string parDamage = "觸發受傷";
        private string parDead = "開關死亡";

        private void Awake()
        {
            ani = GetComponent<Animator>();
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
        }
    }
}
