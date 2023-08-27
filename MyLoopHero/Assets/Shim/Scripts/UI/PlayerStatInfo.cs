using TMPro;
using UnityEngine;

public class PlayerStatInfo : MonoBehaviour
{
    private GameObject playerStatInfo;

    private void Awake()
    {
        playerStatInfo = this.gameObject;
    }

    private void FixedUpdate()
    {
        UpdatePlayerStat();
    }

    private void UpdatePlayerStat()
    {
        playerStatInfo.GetComponent<TMP_Text>().text =
      "Max HP : " + BattleManager.instance.playerKnight.heroHealthMax.ToString() + "\r\n" +
      "Min DMG : " + BattleManager.instance.playerKnight.heroDamageMin.ToString() + "\r\n" +
      "Max DMG : " + BattleManager.instance.playerKnight.heroDamageMax.ToString() + "\r\n" +
      "Magic DMG : " + BattleManager.instance.playerKnight.heroDamageMagic.ToString() + "\r\n" +
      "DMG to All : " + BattleManager.instance.playerKnight.heroDamageAll.ToString() + "\r\n" +
      "Attack Speed : " + BattleManager.instance.playerKnight.heroAttackSpeed.ToString() + "\r\n" +
      "Defence : " + BattleManager.instance.playerKnight.heroDefense.ToString() + "\r\n" +
      "Evade Chance : " + BattleManager.instance.playerKnight.heroEvade.ToString() + "\r\n" +
      "Counter Chance : " + BattleManager.instance.playerKnight.heroCounter.ToString() + "\r\n" +
      "Vamp : " + BattleManager.instance.playerKnight.heroVamp.ToString() + "\r\n" +
      "Regen : " + BattleManager.instance.playerKnight.heroRegen.ToString() + "\r\n" +
      "Day Recovery : " + BattleManager.instance.playerKnight.heroRecovery.ToString();
    }
}
