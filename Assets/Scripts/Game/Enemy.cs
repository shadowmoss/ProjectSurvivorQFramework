using UnityEngine;
using QFramework;

namespace ProjectSurvivor
{
	public partial class Enemy : ViewController
	{
        public float HP = 3;
		public float MovemetSpeed = 2.0f;
        private void Update()
        {
            // 当前是否有player存在
			if (Player.Default) {
                // 求出当前位置指向player的向量
                Vector2 direction = (Player.Default.transform.position - transform.position).normalized;

                transform.Translate(direction * Time.deltaTime * MovemetSpeed);
            }
            if (HP <= 0) {
                UIKit.OpenPanel<UIGamePassPanel>();
                this.DestroyGameObjGracefully();
            }
        }
    }
}
