using RootMotion.FinalIK;
using Z3.NodeGraph.Core;
using Z3.NodeGraph.Tasks;
using UnityEngine;

namespace Z3.NodeGraph.TaskPack.FinalIK
{
    [NgName("Set IK Look At Target")]
    [NodeCategory(Categories.FinalIK)]
    [NodeDescription("TODO")]
    public class SetIKLookAtTarget : ActionTask
    {
        [ParameterDefinition(AutoBindType.SelfBind)]
        [SerializeField] private Parameter<LookAtIK> lookAtIk;
        [SerializeField] private Parameter<Transform> target;

        public override string Info => $"{base.Info} = {target}";

        protected override void StartAction()
        {
            IKSolverLookAt ikLookAt = lookAtIk.Value.GetIKSolver() as IKSolverLookAt;

            ikLookAt.target = target.Value;
            EndAction();
        }
    }
}