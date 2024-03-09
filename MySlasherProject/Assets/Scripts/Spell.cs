using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField]
    private ParticleEndTrigger _bewareParticles;

    [SerializeField]
    private ParticleEndTrigger _attackParticles;

    [SerializeField]
    private MyTriggerAttack _triggerAttack;

    [SerializeField]
    private float _delayBeforeDamage;

    private float _damage;

    [SerializeField]
    private AudioSource audioSource;

    public void Initialize(float damage)
    {
        _damage = damage;
    }

    private void Start()
    {
        _bewareParticles.OnParticlesTopped += StartAttack;

        _attackParticles.OnParticlesTopped += () =>
        {
            Debug.Log("ImpactDamage");
            //_triggerAttack.gameObject.SetActive(true);

            //StartCoroutine(WeirdAttack(_delayBeforeDamage));
            //Destroy(gameObject);
        };

        _bewareParticles.ParticleSystemCurrent.Play();

        _triggerAttack.OnTriggerAttack += Attack;
    }

    public void StartAttack()
    {
        _attackParticles.ParticleSystemCurrent.Play();
        StartCoroutine(WeirdAttack(_delayBeforeDamage));
        //audioSource.Play();
        //Debug.Log("StartAttack");
    }



    public void SetupCollider()
    {
        _triggerAttack.gameObject.SetActive(false);

    }

    public void Attack(Collider collider)
    {

        if (collider.TryGetComponent(out IStunAble enemyController))
        {
            enemyController.GoToStunState();
        }

        if (collider.TryGetComponent(out HealthHandler healthHandler))
        {
            healthHandler.ChangeHealth(-(int)_damage);
        }

    }

    IEnumerator WeirdAttack(float delay)
    {
        yield return new WaitForSeconds(delay);
        _triggerAttack.gameObject.SetActive(true);
        audioSource.Play();


        yield return new WaitForSeconds(0.1f);
        _triggerAttack.gameObject.SetActive(false);
        
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
        //yield return new WaitForSeconds(delay);
        //Destroy(gameObject);

    }

}
