﻿using UFrame.FSM;
using Game.MessageDefine;
using UFrame.ResourceManagement;
using UFrame.ToLua;

namespace Game
{
    public class StateLogin : FSMState
    {
        public bool loginSuccess = false;
        int GameLogic_LoginSuccessed;
        LuaInterface.LuaTable luaMsgTable;
        LuaInterface.LuaFunction luaFunEnter;
        LuaInterface.LuaFunction luaFunLeave;
        public StateLogin(string stateName, FSMMachine fsmCtr) : base(stateName, fsmCtr)
        {
        }

        public override void Enter(string preStateName)
        {
            base.Enter(preStateName);

            loginSuccess = false;
            
            UFrameLuaClient.GetMainState().DoFile("UFrame/Game/GameState/StateLogin.lua");
            luaMsgTable = UFrameLuaClient.GetMainState().GetTable("MessageCode");
            luaFunEnter = UFrameLuaClient.GetMainState().GetFunction("StateLogin.Enter");
            luaFunLeave = UFrameLuaClient.GetMainState().GetFunction("StateLogin.Leave");

            CallLuaFunc(luaFunEnter);

            RegistLuaMessage();
        }

        public override void AddAllConvertCond()
        {
            AddConvertCond("Home", CouldHome);
        }

        public override void Tick(int deltaTimeMS)
        {
        }

        protected override void GetEnterParam()
        {

        }

        protected override void GetLeaveParam()
        {
        }

        public override void Leave()
        {
            UnRegistLuaMessage();
            luaMsgTable.Dispose();
            luaMsgTable = null;

            CallLuaFunc(luaFunLeave);
            base.Leave();
        }

        bool CouldHome()
        {
            return loginSuccess;
        }

        public void MessageCallback(UFrame.MessageCenter.Message msg)
        {
            if (msg.messageID == GameLogic_LoginSuccessed)
            {
                Logger.LogWarp.Log("msg.messageID == GameLogic_LoginSuccessed");
                loginSuccess = true;
            }
        }

        void CallLuaFunc(LuaInterface.LuaFunction luaFun)
        {
            if (luaFun != null)
            {
                luaFun.Call();
                luaFun.Dispose();
                luaFun = null;
            }
        }

        void RegistLuaMessage()
        {
            var luaMsgCode = (luaMsgTable["GameLogic_LoginSuccessed"]);
            if (luaMsgCode != null)
            {
                GameLogic_LoginSuccessed = (int)(double)(luaMsgCode);
                MessageManager.GetInstance().gameMessageCenter.Regist(GameLogic_LoginSuccessed, MessageCallback);
            }
        }


        void UnRegistLuaMessage()
        {
            MessageManager.GetInstance().gameMessageCenter.UnRegist(GameLogic_LoginSuccessed, MessageCallback);
        }

    }
}

