//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class NodeInst
//{
    
//    public InstType type;
//}
//public enum InstType : byte
//{
//    Sequence,
//    Composite,
//    Leaf,
//    Decorator,

//}

//public struct Inst
//{
//    public InstType type;
//    public short arg;
//    public short label;
//    public BehaviourNode behaviour;
//}

//public class Behaviour : MonoBehaviour
//{
//    public List<Inst> insts;
//    public Stack<Inst> stack;
//    int current;

//    private BehaviourNode.State Sequence(BehaviourNode.State result)
//    {
//        int label = insts[current].label;
//        switch (result)
//        {
//            case BehaviourNode.State.FAILURE:
//                current = label - 1;
//                stack.Pop();
//                return BehaviourNode.State.FAILURE;
//            case BehaviourNode.State.SUCCESS:
//                if (current == insts[current].arg)
//                {
//                    stack.Pop();
//                    return BehaviourNode.State.SUCCESS;
//                }

//                Advance();
//                return BehaviourNode.State.RUNNING;
//        }
//        return BehaviourNode.State.FAILURE;
//    }

//    private void FixedUpdate()
//    {
//        Execute();
//    }

//    private void Advance()
//    {
//        current++;
//        if(current == insts.Count)
//        {
//            current = 0;
//        }
//    }

//    public BehaviourNode.State Once(Inst inst)
//    {
//        switch(inst.type)
//        {
//            case InstType.Sequence:
//                stack.Push(inst);
//                Advance();
//                break;
//            case InstType.Leaf:
//                return inst.behaviour.Execute();
//            case InstType.Decorator:
//                var i = inst.behaviour.Execute();

//                break;
//        }
//        return BehaviourNode.State.RUNNING;
//    }

//    public void Execute()
//    {
//        var result = Once(insts[current]);
//        while (result != BehaviourNode.State.RUNNING)
//        {
//            switch (stack.Peek().type)
//            {
//                case InstType.Sequence:
//                    result = Sequence(result);
//                    break;
//            }
//        }
//    }
//}
