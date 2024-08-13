using RootMotion.FinalIK;
using Z3.NodeGraph.Core;
using Z3.NodeGraph.Tasks;
using UnityEngine;

namespace Z3.NodeGraph.TaskPack.FinalIK
{
    [NgName("Set IK Weight")]
    [NodeCategory(Categories.FinalIK)]
    [NodeDescription("TODO")]
    public class SetIKWeight : ActionTask
    {
        [ParameterDefinition(AutoBindType.SelfBind)]
        [SerializeField] private Parameter<IK> ik;

        public bool useSpeed = true;
        //[Slider(0f, 1f)]
        [SerializeField] private Parameter<float> weight;
        //[ShowIf(nameof(useSpeed), 1)]
        [SerializeField] private Parameter<float> duration;

        private float currentWeight;

        public override string Info => $"Set {ik} Weight = {weight}";

        protected override void StartAction()
        {
            if (useSpeed)
            {
                currentWeight = ik.Value.GetIKSolver().GetIKPositionWeight();
            }
            else
            {
                ik.Value.GetIKSolver().SetIKPositionWeight(weight.Value);
                EndAction();
            }
        }

        protected override void UpdateAction()
        {
            currentWeight = Mathf.MoveTowards(currentWeight, weight.Value, 1f / duration.Value * DeltaTime);
            ik.Value.GetIKSolver().SetIKPositionWeight(currentWeight);

            if (currentWeight == weight.Value)
            {
                EndAction();
            }
        }
    }
}