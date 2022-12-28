using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace KID
{
    /// <summary>
    /// 玩家資訊系統：處理攻擊力、金幣與升級處理
    /// </summary>
    public class PlayerDataSystem : MonoBehaviour
    {
        public static float attack = 50;

        private float attackUpdateValue = 50;
        private int coin = 0;
        private int updateCoast = 100;      // 提升攻擊費用
        private TextMeshProUGUI textAttack;
        private TextMeshProUGUI textCoin;
        private Button btnUpdateAttack;

        private float hp = 1000;
        private float hpMax;
        private Image imgHp;

        private void Awake()
        {
            hpMax = hp;

            imgHp = GameObject.Find("血條").GetComponent<Image>();
            textAttack = GameObject.Find("文字攻擊力").GetComponent<TextMeshProUGUI>();
            textCoin = GameObject.Find("文字金幣").GetComponent<TextMeshProUGUI>();
            btnUpdateAttack = GameObject.Find("按鈕升級").GetComponent<Button>();
            btnUpdateAttack.onClick.AddListener(UpdateAttack);

            GetDamage(100);
        }

        /// <summary>
        /// 升級攻擊力
        /// </summary>
        private void UpdateAttack()
        {
            if (coin >= updateCoast)
            {
                coin -= updateCoast;
                attack += attackUpdateValue;

                textCoin.text = "金幣：" + coin;
                textAttack.text = "攻擊力：" + attack;
            }
        }

        /// <summary>
        /// 更新金幣
        /// </summary>
        /// <param name="coinAdd">要增加的金幣</param>
        public void UpdateCoin(int coinAdd)
        {
            coin += coinAdd;
            textCoin.text = "金幣：" + coin;
        }

        /// <summary>
        /// 造成傷害
        /// </summary>
        /// <param name="damage">傷害值</param>
        public void GetDamage(float damage)
        {
            hp -= damage;
            imgHp.fillAmount = hp / hpMax;
        }
    }
}
