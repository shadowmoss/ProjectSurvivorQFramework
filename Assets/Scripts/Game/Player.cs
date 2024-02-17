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
			// hurtBox����ײ�¼�����
			HurtBox.OnTriggerEnter2DEvent(collider2D =>
			{
				this.DestroyGameObjGracefully();
				UIKit.OpenPanel<UIGameOverPanel>();
			}).UnRegisterWhenGameObjectDestroyed(gameObject);
		}

        private void Update()
        {
			// �򵥵ĸ�����������ƶ��Ĵ���
			float horizontal =  Input.GetAxis("Horizontal");	// 1
			float vertical = Input.GetAxis("Vertical");         // 1

			Vector2 direction = new Vector2(horizontal,vertical).normalized;

			// ����������ƶ���������ƶ�
			// TODO ѧϰһ��rigidbody����ӿڡ��������ֱ��transform.Translate������
			SelfRigidbody2D.velocity = direction * movementSpeed;
        }
    }
}
