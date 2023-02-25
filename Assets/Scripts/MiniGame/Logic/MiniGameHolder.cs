using DG.Tweening;
using UnityEngine;

namespace MiniGame
{
    public class MiniGameHolder : Interactive
    {
        [Header("��������")]
        public Transform leftPoint; // ����ײ����

        public Transform rightPoint; // ����ײ����

        //public bool isMove;
        public bool isSelected; // �Ƿ�ѡ��

        public MiniGamePlankType plankType; // ��������

        private float duration = 1f; // �ƶ���ȴʱ��

        private RaycastHit2D hit;

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
                    if (plankType == MiniGamePlankType.Vertical)
                    {
                        transform.DOMove(new Vector3(transform.position.x, transform.position.y + 1, 0), 0.2f);
                        duration = 0.3f;
                    }
                }
                if (isSelected && Input.GetKeyDown(KeyCode.DownArrow))
                {
                    if (plankType == MiniGamePlankType.Vertical)
                    {
                        transform.DOMove(new Vector3(transform.position.x, transform.position.y - 1, 0), 0.2f);
                        duration = 0.3f;
                    }
                }
            }
        }

        private bool PhyciscCheck(Transform tf)
        {
            //Debug.Log(Physics2D.OverlapPoint(tf.position).tag);
            if (Physics2D.OverlapPoint(tf.position))
            {
                return Physics2D.OverlapPoint(tf.position).tag == "Interactive";
            }
            return false;
        }

        public override void EmptyClicked()
        {
            isSelected = !isSelected;
        }
    }
}