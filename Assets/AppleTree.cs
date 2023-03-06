using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {
	[Header("Set in Inspector")]
	// шаблон для создания яблок
	public GameObject applePrefab;

	//скорость движения яблони
	public float speed = 1f;

	// расстояние, на котором должно изменяться направление движения яблони
	public float leftAndRightEdge = 10f;

	// вероятность случайного изменения направления движения
	public float chanceToChangeDirections = 0.1f;

	// частота создания экземпляров яблок
	public float secondsBetweenAppleDrops = 1f;

	void Start () {
		// сбрасывать яблоки раз в секунду	
		Invoke( "DropApple", 2f );
	}

	void DropApple() {
		GameObject apple = Instantiate<GameObject> (applePrefab);
		apple.transform.position = transform.position;
		Invoke ("DropApple", secondsBetweenAppleDrops);
	}
	
	void Update () {
		// простое перемещение
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;

		// изменение направления
		if (pos.x < -leftAndRightEdge) {
			speed = Mathf.Abs (speed); // начать движение вправо
		} else if (pos.x > leftAndRightEdge) {
			speed = -Mathf.Abs (speed); // начать движение влево
		} 
	}

	void FixedUpdate() {
		// теперь случайная смена направления привязана к реальному времени
		// потому что выполняется в FixedUpdate()
		if ( Random.value < chanceToChangeDirections ) {
			speed *= -1; // сменить направление
		}
	}
}
