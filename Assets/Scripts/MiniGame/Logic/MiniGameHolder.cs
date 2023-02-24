using DG.Tweening;
using UnityEngine;

namespace MiniGame
{
    public class MiniGameHolder : Interactive
    {
        [Header("横条属性")]
        public Transform leftPoint; // 左碰撞检测点

        public Transform rightPoint; // 右碰撞检测点
        public Transform topPoint; // 上碰撞检测点
        public Transform bottomPoint; // 下碰撞检测点
        public bool isSelected; // 是否被选中
        public MiniGamePlankType plankType; // 横条类型

        private float duration = 1f; // 移动冷却时间

        private void Update()
        {
            duration -= Time.deltaTime;
            Move();
        }

        // 移动方块
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
        /// 物理检测
        /// </summary>
        /// <param name="tf">碰撞点位置</param>
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

        // 物品空点
        public override void EmptyClicked()
        {
            isSelected = !isSelected;
        }
    }
}