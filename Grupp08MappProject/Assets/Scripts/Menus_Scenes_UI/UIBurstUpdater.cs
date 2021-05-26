using UnityEngine;

public class UIBurstUpdater : MonoBehaviour
{
    public GameObject[] bursts;

    private void OnEnable()
    {
        PlayerState.updateBurst += DecreaseActiveBursts;
        PlayerState.updateBurst += IncreaseActiveBursts;
    }

    private void OnDisable()
    {
        PlayerState.updateBurst -= DecreaseActiveBursts;
        PlayerState.updateBurst -= IncreaseActiveBursts;
    }

    private void DecreaseActiveBursts(PlayerState state)
    {
        for (int i = state.GetBursts(); i < bursts.Length; i++)
        {
            bursts[i].SetActive(false);
        }
    }

    private void IncreaseActiveBursts(PlayerState state)
    {
        for(int i = 0; i < state.GetBursts(); i++)
        {
            bursts[i].SetActive(true);
        }
    }

}
