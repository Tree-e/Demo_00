using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;//引入命名空间
public class Test_autoDo : MonoBehaviour
{
    public Vector3 OriginalValue;//起始位置
    public Vector3 currentValue;//当前位置
    public Vector3 targetValue;//目标位置
    public Transform CubeTransform;//获得Cube的引用
    void Start()
    {
        OriginalValue = CubeTransform.position;
        targetValue = new Vector3(10, 10, 10);
        currentValue = transform.position;
        //对一个变量做动画,当前值渐变到目标值(类似插值),值的变化速度是由快到慢.
        //currentValue 可以使float类型的或者其他的... ,目标值(targetValue)的类型要和currentValue保持一致
        //DOTween.To(() => currentValue, x => currentValue = x, targetValue, 2);
        transform.DOMove(targetValue, 3, false);
        transform.DORotate(new Vector3(90, 0, 0), 3);
    }

    void Update()
    {
        //if (CubeTransform.position == targetValue)
        //{
        //    transform.DORotate(OriginalValue, 0.3f, RotateMode.FastBeyond360);
        //}
        //CubeTransform.position = currentValue;
    }
}
