using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // эта строка подключает библиотеку для работы с ГИП

public class Basket : MonoBehaviour {
	[Header("Set Dinamically")]
	public Text scoreGT;

	void Start() {
		// получить ссылку на игровой объект ScoreCounter
		GameObject scoreGO = GameObject.Find("ScoreCounter");
		// получить компонент Text этого игрового объекта
		scoreGT = scoreGO.GetComponent<Text>();
		// установить начальное число очков равным 0
		scoreGT.text = "0";
	}

	// Update is called once per frame
	void Update () {
		// получить текущие координаты указателя мыши на экране через Input
		Vector3 mousePos2D = Input.mousePosition;

		// координата Z камеры определяет, как далеко в трёхмерном пространстве находится указатель мыши
		mousePos2D.z = -Camera.main.transform.position.z;

		// преобразовать точку на двумерной плоскости экрана в трёхмерные координаты игры
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint( mousePos2D );

		// переместить корзину вдоль оси X в координату X указателя мыши
		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;		
	}

	void OnCollisionEnter( Collision coll ) {
		// отыскать яблоко, попавшее в эту корзину
		GameObject collidedWith = coll.gameObject;
		if (collidedWith.tag == "Apple") {
			Destroy (collidedWith);

			// преобразовать текст в scoreGT в целое число
			int score = int.Parse( scoreGT.text );
			// добавить очки за пойманное яблоко
			score += 100;
			// преобразовать число очков обратно в строку и вывести ее на экран
			scoreGT.text = score.ToString();

			// запомнить высшее достижение
			if (score > HighScore.score) {
				HighScore.score = score;
			}
		}
	}
}
