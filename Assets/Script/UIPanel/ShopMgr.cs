﻿using UnityEngine;
using System.Collections;
using System;
using Boo.Lang;
using UnityEngine.UI;
public class ShopMgr : MonoBehaviour
{
    private static ShopMgr _instance;
    public static ShopMgr Instance
    { get { return _instance; } }

    private Image _propPanel;
    private Image _rechargePanel;
    private Image _propConfrimPanel;
    private Image _rechargeConfrimPanelOne;
    private Image _welfarePanel;
    private Text _propConfirmCoinNum;//购买所对应的金币数量
    private Text _propCoinNum;//购买所需金币的数量
    private Sprite goodConfirmSprite;//购买的商品对应的图标
    private int goodId;//购买商品所对应的id
    private Text _rechargeCoinNum;//充值所需金币数量
    private Text _rechargeDiamondsNum;//获得钻石数量
    private int _coinNum;
    private int _diamondNum;
    internal void Init()
    {
        gameObject.FindComponent<Button>("closeBtn").onClick.AddListener(CloseThisPanel);
        gameObject.FindComponent<Button>("rechargeBtn").onClick.AddListener(RechargeOpration);
        gameObject.FindComponent<Button>("propBtn").onClick.AddListener(PropSystemOpration);
        gameObject.FindComponent<Button>("welfareBtn").onClick.AddListener(WelfarePanel);

        //道具面板
        _propPanel = gameObject.FindComponent<Image>("PropPanel");
        _propPanel.gameObject.SetActive(false);

        //道具确认购买界面
        _propConfrimPanel = gameObject.FindComponent<Image>("PropConfirmPanel");
        _propConfrimPanel.gameObject.SetActive(false);
        PropConfirmPanel();
        _propConfrimPanel.gameObject.FindComponent<Button>("bg/Cancel").onClick.AddListener(ClosePropConfirmPanel);
        _propConfirmCoinNum = _propConfrimPanel.gameObject.FindComponent<Text>("bg/coins/num");
        goodConfirmSprite = _propConfrimPanel.gameObject.FindComponent<Image>("bg/TargetSprite").sprite;
        //充值面板
        _rechargePanel = gameObject.FindComponent<Image>("rechargePanel");
        _rechargePanel.gameObject.SetActive(true);

        //充值确认界面1
        _rechargeConfrimPanelOne = gameObject.FindComponent<Image>("rechargeConfirmPanelOne");
        _rechargeConfrimPanelOne.gameObject.SetActive(false);
        RechargeConfirmPanel();
        _rechargeConfrimPanelOne.gameObject.FindComponent<Button>("bg/Ok").onClick.AddListener(() => CloseRechargeConfirmPanelOne(_coinNum.ToString(), _diamondNum.ToString()));
        _rechargeConfrimPanelOne.gameObject.FindComponent<Button>("bg/Cancel").onClick.AddListener(CloseRechargeConfirmPanelOne);
        _rechargeCoinNum = _rechargeConfrimPanelOne.gameObject.FindComponent<Text>("bg/coins/num");
        _rechargeDiamondsNum = _rechargeConfrimPanelOne.gameObject.FindComponent<Text>("bg/Diamonds/num");

        //福利面板 暂未开启
        _welfarePanel = gameObject.FindComponent<Image>("welfarePanel");
        _welfarePanel.gameObject.SetActive(false);

    }



    //福利界面切换按钮
    private void WelfarePanel()
    {
        _propPanel.gameObject.SetActive(false);
        _rechargePanel.gameObject.SetActive(false);
        _welfarePanel.gameObject.SetActive(true);
    }

    //道具面板切换按钮
    private void PropSystemOpration()
    {
        _propPanel.gameObject.SetActive(true);
        _rechargePanel.gameObject.SetActive(false);
        _welfarePanel.gameObject.SetActive(false);
    }
    //道具购买界面
    private void PropConfirmPanel()
    {
        Image grid = _propPanel.gameObject.FindComponent<Image>("Grid");
        for (int i = 0; i < grid.gameObject.transform.childCount; i++)
        {

            grid.gameObject.transform.GetChild(i).gameObject.FindComponent<Text>("goodName").text = ShopTable.Instance[i + 1].Name;
            var mapPath = ShopTable.Instance[i + 1].Sprite;
            grid.gameObject.transform.GetChild(i).gameObject.FindComponent<Image>("goodImage").overrideSprite = Resources.Load(mapPath, typeof(Sprite)) as Sprite;
            _propCoinNum = grid.gameObject.transform.GetChild(i).gameObject.FindComponent<Text>("coinNum");
            _propCoinNum.text = ShopTable.Instance[i + 1].Price.ToString();
            grid.gameObject.transform.GetChild(i).GetComponent<Toggle>().onValueChanged.AddListener((isOn) => OpenPropConfirmPanel(_propCoinNum.text, Resources.Load(mapPath, typeof(Sprite)) as Sprite));
            _propConfrimPanel.gameObject.FindComponent<Button>("bg/Ok").onClick.AddListener(() => ClosePropConfirmPanel(goodId, _propCoinNum.text, 1));
        }
    }
    //道具购买界面的控制
    private void OpenPropConfirmPanel(string text, Sprite goodSprite)
    {
        _propConfrimPanel.gameObject.SetActive(true);
        _propConfirmCoinNum.text = text;
        goodConfirmSprite = goodSprite;

    }
    private void ClosePropConfirmPanel(int itemId, string _coinNum, int itemNum)
    {
        if (RoleMgr.Instance.Money > int.Parse(_coinNum))
        {
            RoleMgr.Instance.Money -= int.Parse(_coinNum);
            //PacketModel.Instance.Save(itemId, itemNum);
            //foreach (var itemIndex in PacketModel.Instance.packetList)
            //{
            //   Debug.Log("背包为物品 ： "+ itemIndex); 
            //}
            Debug.Log("玩家买完商品剩余的钱 ： " +RoleMgr.Instance.Money);
        }
        _propConfrimPanel.gameObject.SetActive(false);
    }
    private void ClosePropConfirmPanel()
    {
        _propConfrimPanel.gameObject.SetActive(false);
    }
    //充值面板切换按钮
    private void RechargeOpration()
    {
        _propPanel.gameObject.SetActive(false);
        _rechargePanel.gameObject.SetActive(true);
        _welfarePanel.gameObject.SetActive(false);
    }
    //充值界面的控制
    private void RechargeConfirmPanel()
    {
        Image grid = _rechargePanel.gameObject.FindComponent<Image>("Grid");
        for (int i = 0; i < grid.gameObject.transform.childCount; i++)
        {
            string textCoin = grid.gameObject.transform.GetChild(i).gameObject.FindComponent<Text>("coinNum").text;
            string DiamondsNum = grid.gameObject.transform.GetChild(i).gameObject.FindComponent<Text>("goodImage/Text").text;
            grid.gameObject.transform.GetChild(i).GetComponent<Toggle>().onValueChanged.AddListener((isOn) => OpenRechargeConfirmPanelOne(textCoin, DiamondsNum));

        }
    }

    private void OpenRechargeConfirmPanelOne(string textCoin, string diamondsNum)
    {
        _rechargeConfrimPanelOne.gameObject.SetActive(true);
        _rechargeCoinNum.text = textCoin;
        _rechargeDiamondsNum.text = diamondsNum;
        _coinNum = int.Parse(textCoin);
        _diamondNum = int.Parse(diamondsNum);
    }

    private void CloseRechargeConfirmPanelOne(string textCoin, string diamondsNum)
    {
        if (RoleMgr.Instance.Money >= int.Parse(textCoin))
        {
            RoleMgr.Instance.Money -= int.Parse(textCoin);
            RoleMgr.Instance.Diamond += int.Parse(diamondsNum);
        }
        _rechargeConfrimPanelOne.gameObject.SetActive(false);
        Debug.Log("RoleMgr Money :" + RoleMgr.Instance.Money);
    }
    private void CloseRechargeConfirmPanelOne()
    {
        _rechargeConfrimPanelOne.gameObject.SetActive(false);
    }
    //关闭面板按钮
    private void CloseThisPanel()
    {
        gameObject.SetActive(false);
    }
}
