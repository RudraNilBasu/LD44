using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Fire : MonoBehaviour {

    SpriteRenderer m_sprite_renderer;

    [SerializeField]
    Sprite[] m_sprites;

	// Use this for initialization
	void Start () {
		StartCoroutine(PlayAnim());
        m_sprite_renderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator PlayAnim()
    {
        int i = 0;
        while(true) {
            yield return new WaitForSeconds(0.5f);
            i++;
            if (i >= 3) {
                i = 0;
            }
            m_sprite_renderer.sprite = m_sprites[i];
        }
    }
}
