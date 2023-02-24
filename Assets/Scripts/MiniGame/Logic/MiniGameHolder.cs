using DG.Tweening;
using UnityEngine;

namespace MiniGame
{
    public class MiniGameHolder : Interactive
    {
        [Header("��������")]
        public Transform leftPoint; // ����ײ����

        public Transform rightPoint; // ����ײ����
        public Transform topPoint; // ����ײ����
        public Transform bottomPoint; // ����ײ����
        public bool isSelected; // �Ƿ�ѡ��
        public MiniGamePlankType plankType; // ��������

        private float duration = 1f; // �ƶ���ȴʱ��

        private void Update()
        {
            duration -= Time.deltaTime;
            Move();
        }

        // �ƶ�����
        private void Move()
        {
            if (duration <= 0)
            {
                if (isSelected && Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    if (PhyciscCheck(leftPoint)) return;
                    if (plankType == MiniGamePlankType.Horizontal || plankType == MiniGamePlankType.Key)
                    {
                        transform.DOMove(new Vector3(transform.position.x - 1, transform.position.y, 0), 0.2f);
                        duration = 0.3f;
                    }
                }
                if (isSelected && Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (PhyciscCheck(rightPoint)) return;
                    if (plankType == MiniGamePlankType.Horizontal || plankType == MiniGamePlankType.Key)
                    {
                        transform.DOMove(new Vector3(transform.position.x + 1, transform.position.y, 0), 0.2f);
                        duration = 0.3f;
                    }
                }
                if (isSelected && Input.GetKeyDown(KeyCode.UpArrow))
                {
                    if (PhyciscCheck(topPoint)) return;
                    if (plankType == MiniGamePlankType.Vertical)
                    {
                        transform.DOMove(new Vector3(transform.position.x, transform.position.y + 1, 0), 0.2f);
                        duration = 0.3f;
                    }
                }
                if (isSelected && Input.GetKeyDown(KeyCode.DownArrow))
                {
                    if (PhyciscCheck(bottomPoint)) return;
                    if (plankType == MiniGamePlankType.Vertical)
                    {
                        transform.DOMove(new Vector3(transform.position.x, transform.position.y - 1, 0), 0.2f);
                        duration = 0.3f;
                    }
                }
            }
        }

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="tf">��ײ��λ��</param>
        /// <returns></returns>
        private bool PhyciscCheck(Transform tf)
        {
            //Debug.Log(Physics2D.OverlapPoint(tf.position).tag);
            if (tf == null) return false;
            if (Physics2D.OverlapPoint(tf.position))
            {
                return Physics2D.OverlapPoint(tf.position).tag == "Interactive";
            }
            return false;
        }

        // ��Ʒ�յ�
        public override void EmptyClicked()
        {
            isSelected = !isSelected;
        }
    }
}