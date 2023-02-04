using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthAttacks : MonoBehaviour
{
    List<int> attacksList = new List<int>();
    public GameObject spitGameObject;
    public float spitDuration = 3f;
    public HealthManager healthManager;

    public bool canChomp = true;
    public bool canSpit = false;
    public bool canBadBreath = false;
    public float badBreathDuration = 3.0f;
    public ParticleSystem badBreathParticleSystem;

    public float attackCooldown = 2.0f;
    float currentAttackCooldown;

    bool isAttacking = false;

    public Animator chompAnimator;

    private void Start()
    {
        if (canChomp) attacksList.Add(0);
        if (canSpit) attacksList.Add(1);
        if (canBadBreath) attacksList.Add(2);

    }

    private void Update()
    {
        //Debug.Log("CurrentAttackCooldown:" + currentAttackCooldown);
        if (!isAttacking) currentAttackCooldown += Time.deltaTime;

        if (currentAttackCooldown >= attackCooldown)
        {
            isAttacking = true;
            currentAttackCooldown = 0f;

            int attackSelector = Random.Range(0, attacksList.Count);

            Debug.Log("AttackSelector:" + attackSelector);
            Debug.Log("AttackElement:" + attacksList[attackSelector]);

            switch(attacksList[attackSelector])
            {
                case 0:
                    Attack_Chomp();
                    break;
                case 1:
                    Attack_Spit();
                    break;
                case 2:
                    Attack_BadBreath();
                    break;
            }
        }
    }

    public void resetIsAttacking()
    {
        isAttacking = false;
        Debug.Log("CanAttack Again");
    }

    void Attack_Chomp()
    {
        Debug.Log("Chomp");
        chompAnimator.Play("Base Layer.Chomp", 0);
    }

    void Attack_Spit()
    {
        Debug.Log("Spit");
        healthManager.isBlind = true;
        spitGameObject.SetActive(true);
        StartCoroutine(SpitCooldownRoutine());
        isAttacking = false;
    }

    void Attack_BadBreath()
    {
        Debug.Log("BadBreath");
        StartCoroutine(BadBreathRoutine());
    }

    IEnumerator SpitCooldownRoutine()
    {
        float timer = 0f;

        while(timer<spitDuration)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        spitGameObject.SetActive(false);
    }

    IEnumerator BadBreathRoutine()
    {
        float totalDurationTimer = 0f;
        float intervalTimer = 0f;

        badBreathParticleSystem.Play();

        while (totalDurationTimer < badBreathDuration)
        {
            totalDurationTimer += Time.deltaTime;
            intervalTimer += Time.deltaTime;

            if(intervalTimer>= 1.0f)
            {
                intervalTimer = 0.0f;
                healthManager.TakeDPSDamage(30);
            }

            yield return null;
        }

        isAttacking = false;
    }
}
