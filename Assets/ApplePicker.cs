using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour {
	[Header("Set in Inspector")]
	public GameObject basketPrefab;
	public int numBaskets = 3;
	public float basketBottomY = -14f;
	public float basketSpacingY = 2f;
	public List<GameObject> basketList;
	 
	void Start () {
		basketList = new List<GameObject> ();
		for (int i = 0; i < numBaskets; i++) {
			GameObject tBasketGO = Instantiate<GameObject> (basketPrefab);
			Vector3 pos = Vector3.zero;
			pos.y = basketBottomY + (basketSpacingY * i);
			tBasketGO.transform.position = pos;
			basketList.Add (tBasketGO);
		}
	}
	public void AppleDestroyed() {
		// удалить все упавшие яблоки
		GameObject[] tAppleArray=GameObject.FindGameObjectsWithTag("Apple");
		foreach ( GameObject tGO in tAppleArray ) {
			Destroy( tGO );
		}

		// удалить одну корзину
		// получить индекс последней корзины в basketList
		int basketIndex = basketList.Count-1;
		// получить ссылку на этот игровой объект Basket
		GameObject tBasketGO = basketList[basketIndex];
		// исключить корзину из списка и удалить сам игровой объект
		basketList.RemoveAt( basketIndex );
		Destroy (tBasketGO);

		// если корзин не осталось, перезапустить игру
		if (basketList.Count == 0) {
			SceneManager.LoadScene ("_Scene_0");
		}
	}
}

	
