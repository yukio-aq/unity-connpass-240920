using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public float interactionRange = 2f;
    public LayerMask interactableLayers;

    public void HandleInteraction(Vector3 rayOrigin, Vector3 rayDirection)
    {
        Debug.Log($"HandleInteraction called. Range: {interactionRange}, Layers: {interactableLayers.value}");
        if (Physics.Raycast(rayOrigin, rayDirection, out RaycastHit hitInfo, interactionRange, interactableLayers))
        {
            Debug.Log($"Raycast hit: {hitInfo.collider.gameObject.name}, Tag: {hitInfo.collider.tag}");
            switch (hitInfo.collider.tag)
            {
                case "Door":
                    InteractWithDoor(hitInfo.collider.gameObject);
                    break;
                case "Item":
                    //InteractWithItem(hitInfo.collider.gameObject);
                    break;
                default:
                    Debug.Log($"Interacting with unknown object: {hitInfo.collider.tag}");
                    break;
            }
        }
        else
        {
            Debug.Log("Raycast did not hit any object");
        }
    }

    private void InteractWithDoor(GameObject door)
    {
        Debug.Log($"Attempting to interact with door: {door.name}");
        Door doorComponent = door.GetComponent<Door>();
        if (doorComponent != null)
        {
            doorComponent.Interact();
        }
        else
        {
            Debug.LogError($"Door object {door.name} does not have a Door component");
        }
    }

    //private void InteractWithItem(GameObject item)
    //{
    //    Item itemComponent = item.GetComponent<Item>();
    //    if (itemComponent != null)
    //    {
    //       itemComponent.interact();
    //    }
    //    else
    //    {
    //        Debug.Log("Item object does not have an Item component");
    //    }
    //}
}