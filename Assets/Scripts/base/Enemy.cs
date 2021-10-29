using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    public float hd;
    public float damage;

    public SpriteRenderer sprenderer;
    private Color originalColor;
    public ParticleSystem bloodEffect;

    // Start is called before the first frame update
    public void Start()
    {
        sprenderer = GetComponent<SpriteRenderer>();
        originalColor = sprenderer.color;
    }

    // Update is called once per frame
    public void Update()
    {
        if (hd <= 0) {
            Destroy(gameObject);
        }
    }

    public void GiveDamage(float damage) {
        hd -= damage;
        StartCoroutine("FlashColor");

        ParticleSystem obj = Instantiate(bloodEffect, transform.position, Quaternion.identity);
        Destroy(obj.gameObject, 0.8f);

        // CameraFollow.instance.Shake();
    }

    private IEnumerator FlashColor() {
        sprenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprenderer.color = originalColor;
    }
}
