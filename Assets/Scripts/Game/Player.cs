using UnityEngine;
using QFramework;

namespace ProjectSurvivor
{
	public partial class Player : ViewController
	{
		public float movementSpeed = 5.0f;

        public static Player Default;

        private void Awake()
        {
			Default = this;
        }
        private void OnDestroy()
        {
			Default = null;
        }
        void Start()
		{
			// Code Here
			"Hello World!".LogInfo();
			// hurtBox的碰撞事件监听
			HurtBox.OnTriggerEnter2DEvent(collider2D =>
			{
				this.DestroyGameObjGracefully();
				UIKit.OpenPanel<UIGameOverPanel>();
			}).UnRegisterWhenGameObjectDestroyed(gameObject);
		}

        private void Update()
        {
			// 简单的根据输入进行移动的代码
			float horizontal =  Input.GetAxis("Horizontal");	// 1
			float vertical = Input.GetAxis("Vertical");         // 1

			Vector2 direction = new Vector2(horizontal,vertical).normalized;

			// 根据输入的移动方向进行移动
			// TODO 学习一下rigidbody组件接口。改这里和直接transform.Translate的区别
			SelfRigidbody2D.velocity = direction * movementSpeed;
        }
    }
}
