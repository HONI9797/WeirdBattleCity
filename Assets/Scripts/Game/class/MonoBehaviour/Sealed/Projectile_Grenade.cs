
using System.Collections;

public class Projectile_Grenade : Projectile
{
    public override ProjectileCode projectileCode => ProjectileCode.Grenade;

    protected override IEnumerator Launch_(ProjectileInfo projectileInfo)
    {
        _rigidbody.velocity = transform.forward * projectileInfo.force;

        yield return CoroutineWizard.WaitForSeconds(projectileInfo.lifeTime);

        _attackBox.Check((hitBox) => { if (hitBox != null) _actionOnHit.Invoke(hitBox); });

        var audioSourceMaster = AudioMaster.instance.Pop(AudioClipCode.Explosion_0);

        audioSourceMaster.transform.position = transform.position;

        audioSourceMaster.gameObject.SetActive(true);

        audioSourceMaster.Play();

        PlayParticleEffect(transform.position, ParticleEffectCode.Explosion);

        Disable();
    }
}