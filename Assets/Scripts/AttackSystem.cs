using UnityEngine;

namespace KID
{
    /// <summary>
    /// �����t�ΡG�P�_�n����������öǻ��ˮ`
    /// </summary>
    public class AttackSystem : MonoBehaviour
    {
        [SerializeField, Header("�n����������W��")]
        private string nameTarget;
        [SerializeField, Header("�����O"), Range(0, 5000)]
        private float attack;

        private void OnCollisionEnter(Collision collision)
        {
            // �p�G �I�쪫��W�� �]�t �n����������W��
            if (collision.gameObject.name.Contains(nameTarget))
            {
                // �I�쪫����o�ˮ`�t�� �� �I�s �y���ˮ`(�����O)
                collision.gameObject.GetComponent<DamageSystem>().GetDamage(attack);
            }
        }
    }
}
