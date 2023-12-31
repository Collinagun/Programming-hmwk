using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    
    private Coroutine timerCoroutine;
    protected float curChargeTime;
    private bool atkTimerDone = true;

    protected Rigidbody owner;

    [SerializeField] public float contactDamage;
    [SerializeField] public float chargeTime;
    [SerializeField] public float minCharge;

    public WaitForSeconds CoolDown;
    [SerializeField] public float cooldown;
    

    private void OnEnable()
    {
        CoolDown = new WaitForSeconds(cooldown);
    }

    protected abstract void Attack(float chargePercent);

    protected virtual bool CanAttack()
    {
        return atkTimerDone;
    }

    private void TryAttack(float percent)
    {
        if(percent < minCharge){
            return;
        }

        Attack(percent);
            StartCoroutine(CoolDownTimer());
    }
    
    private IEnumerator CoolDownTimer()
    {
        atkTimerDone = false;
        yield return CoolDown;
        atkTimerDone = true;
    }

    public void StartAttack()
    {
        timerCoroutine = StartCoroutine(HandleCharge());
    }
     private IEnumerator HandleCharge()
     {
        curChargeTime = 0;
        print("StartCharge");
        yield return new WaitUntil(()=> atkTimerDone);
        print("CoolDownDone");

        while(curChargeTime < chargeTime){
            curChargeTime += Time.deltaTime;
            yield return null;
        }
        print("Attack Completed");
        TryAttack(1);
        timerCoroutine = StartCoroutine(HandleCharge());
     }

    public void EndAttack()
    {
        StopCoroutine(timerCoroutine);
            TryAttack(curChargeTime/chargeTime);
    }
}
