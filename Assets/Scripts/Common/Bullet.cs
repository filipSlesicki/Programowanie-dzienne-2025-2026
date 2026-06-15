using System.Collections.Generic;
using TowerDefence;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolable
{
    public float speed = 10f;
    public string ignoreTag;

    [HideInInspector]
    public int hitsRemaining;

    private ObjectPool pool;
    private HitEffectData[] hitEffects;
    private BulletModifierData modifier;

    public static List<Bullet> bullets = new();

    public void SetPool(ObjectPool objectPool) => pool = objectPool;

    public void Configure(HitEffectData[] effects, BulletModifierData bulletModifier)
    {
        hitEffects = effects;
        modifier = bulletModifier;
        hitsRemaining = bulletModifier is PierceBulletModifier pierce ? pierce.PierceCount : 0;
    }

    private void OnEnable()
    {
        Invoke(nameof(Release), 3f);
        bullets.Add(this);
    }

    private void OnDisable()
    {
        bullets.Remove(this);
        CancelInvoke();
        hitEffects = null;
        modifier = null;
        hitsRemaining = 0;
    }

    private void Release() => pool.Release(gameObject);

    private void Update() => transform.position += transform.forward * speed * Time.deltaTime;

    private void OnTriggerEnter(Collider other)
    {
        if (!string.IsNullOrEmpty(ignoreTag) && other.CompareTag(ignoreTag))
            return;

        Health health = other.GetComponent<Health>();
        if (health == null)
            return;

        if (hitEffects != null)
        {
            Vector3 hitPos = transform.position;
            foreach (HitEffectData effect in hitEffects)
                effect.ApplyTo(health, hitPos);
        }

        bool shouldRelease = modifier == null || modifier.OnBulletHit(this, health);
        if (shouldRelease)
            pool.Release(gameObject);
    }
}
