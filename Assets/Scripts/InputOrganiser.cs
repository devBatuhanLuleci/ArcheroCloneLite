using UnityEngine;

namespace ArcheroLite
{

public class InputOrganizaser : MonoBehaviour
{
    [Header("Output")]
    public InputHandler StarterAssetsInputs;

    public void VirtualMoveInput(Vector2 virtualMoveDirection)
    {
        StarterAssetsInputs.MoveInput(virtualMoveDirection);
    }

}
}