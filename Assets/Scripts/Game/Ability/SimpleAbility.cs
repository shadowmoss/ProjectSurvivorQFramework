using UnityEngine;
using QFramework;

namespace ProjectSurvivor
{
	public partial class SimpleAbility : ViewController
	{
		float mCurrentSeconds = 0;
		void Start()
		{
			// Code Here
		}
        private void Update()
        {
			mCurrentSeconds += Time.deltaTime;
			if (mCurrentSeconds >= 1.5f) {
				mCurrentSeconds = 0;
				Enemy[] enemies =  FindObjectsByType<Enemy>(FindObjectsInactive.Exclude,FindObjectsSortMode.None);
				foreach (Enemy item in enemies) {
					float distance = (Player.Default.transform.position - item.transform.position).magnitude;
					if (distance <= 5) {
						item.Sprite.color = Color.red;
						Enemy enemyRefCache = item;
						ActionKit.Delay(0.3f,()=>{
							enemyRefCache.HP--;
							item.Sprite.color = Color.white;

                        }).StartGlobal();
					}
                }
			}
        }
    }
}
