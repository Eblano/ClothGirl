using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateDeathPuff : StateMachineBehaviour {
    public GameObject deathpuff;
    public float xOffset = 0;
    public float yOffset = 0;
    //public GameObject target;
    public float randomUnitSize = .5f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Instantiate(deathpuff, animator.transform);
        //for(int i = 0; i<10;i++)
        //{
        //    Vector3 randPoint = Random.insideUnitCircle * 5;
        //    Vector3 tempPosition = animator.transform.position;
        //   tempPosition += yOffset * Vector3.up + xOffset* Vector3.right*i;
        //    //Transform tempTrans = new Transform();
        //    //tempTrans.position = tempPosition;
        //    GameObject temp = Instantiate(deathpuff, animator.transform);
        //    //temp.transform.position = Random.insideUnitCircle * randomUnitSize;
        //    //temp.transform.position = animator.transform.position;
        //    //Instantiate(deathpuff, randPoint.tran);

        //}
        //Instantiate(deathpuff);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
