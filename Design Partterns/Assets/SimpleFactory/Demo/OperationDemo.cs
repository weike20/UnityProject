using UnityEngine;
using System.Collections;

public class OperationDemo : MonoBehaviour
{

    private OperationFactory operationFactory = new OperationFactory();
	void Start ()
    {
        OperationBase operationAdd =  operationFactory.CreateOperation("+");
        operationAdd.NumberA = 10;
        operationAdd.NumberB = 20;
        float result = operationAdd.CalculateResult();
        Debug.Log("NumberA: " + operationAdd.NumberA + "NumberB: " + operationAdd.NumberB + "result: " + result);
	}
}
