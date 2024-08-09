using RootMotion.FinalIK;
using Z3.NodeGraph.Core;
using Z3.NodeGraph.Tasks;
using UnityEngine;

namespace Z3.NodeGraph.TaskPack.FinalIK
{
    [NgName("Set IK Aim Target")]
    [NodeCategory(Categories.FinalIK)]
    [NodeDescription("TODO")]
    public class SetIKAimTarget : ActionTask
    {
        [ParameterDefinition(AutoBindType.SelfBind)]
        [SerializeField] private Parameter<AimIK> aimIk;
        [SerializeField] private Parameter<Transform> target;

        public override string Info => $"{base.Info} = {target}";

        protected override void StartAction()
        {
            IKSolverAim ikAim = aimIk.Value.GetIKSolver() as IKSolverAim;

            ikAim.target = target.Value;
            EndAction();
        }
    }
}