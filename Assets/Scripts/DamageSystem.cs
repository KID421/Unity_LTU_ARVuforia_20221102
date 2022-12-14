using UnityEngine;
using UnityEngine.UI;

namespace KID
{
    /// <summary>
    /// �ˮ`�t�ΡG�x�s��q�B�P�_����P���`
    /// </summary>
    public class DamageSystem : MonoBehaviour
    {
        [SerializeField, Header("��q"), Range(0, 5000)]
        private float hp;
        [SerializeField, Header("���")]
        private Image imgHp;

        private float maxHp;
        private Animator ani;
        private string parDamage = "Ĳ�o����";
        private string parDead = "�}�����`";

        private void Awake()
        {
            ani = GetComponent<Animator>();
            maxHp = hp;
        }

        /// <summary>
        /// �y���ˮ`
        /// </summary>
        /// <param name="damage">�ˮ`��</param>
        public void GetDamage(float damage)
        {
            hp -= damage;
            imgHp.fillAmount = hp / maxHp;
            ani.SetTrigger(parDamage);

            if (hp <= 0) Dead();
        }

        /// <summary>
        /// ���`
        /// </summary>
        private void Dead()
        {
            ani.SetBool(parDead, true);
        }
    }
}
