﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class Game_MessageManagerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Game.MessageManager), typeof(UFrame.Common.Singleton<Game.MessageManager>));
		L.RegFunction("Init", Init);
		L.RegFunction("Tick", Tick);
		L.RegFunction("Regist", Regist);
		L.RegFunction("UnRegist", UnRegist);
		L.RegFunction("Send", Send);
		L.RegFunction("New", _CreateGame_MessageManager);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("gameMessageCenter", get_gameMessageCenter, set_gameMessageCenter);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateGame_MessageManager(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				Game.MessageManager obj = new Game.MessageManager();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: Game.MessageManager.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Init(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Game.MessageManager obj = (Game.MessageManager)ToLua.CheckObject<Game.MessageManager>(L, 1);
			obj.Init();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Tick(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Game.MessageManager obj = (Game.MessageManager)ToLua.CheckObject<Game.MessageManager>(L, 1);
			obj.Tick();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Regist(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Game.MessageManager obj = (Game.MessageManager)ToLua.CheckObject<Game.MessageManager>(L, 1);
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			System.Action<UFrame.MessageCenter.Message> arg1 = (System.Action<UFrame.MessageCenter.Message>)ToLua.CheckDelegate<System.Action<UFrame.MessageCenter.Message>>(L, 3);
			obj.Regist(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnRegist(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Game.MessageManager obj = (Game.MessageManager)ToLua.CheckObject<Game.MessageManager>(L, 1);
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			System.Action<UFrame.MessageCenter.Message> arg1 = (System.Action<UFrame.MessageCenter.Message>)ToLua.CheckDelegate<System.Action<UFrame.MessageCenter.Message>>(L, 3);
			obj.UnRegist(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Send(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				Game.MessageManager obj = (Game.MessageManager)ToLua.CheckObject<Game.MessageManager>(L, 1);
				UFrame.MessageCenter.Message arg0 = (UFrame.MessageCenter.Message)ToLua.CheckObject<UFrame.MessageCenter.Message>(L, 2);
				obj.Send(arg0);
				return 0;
			}
			else if (count == 3)
			{
				Game.MessageManager obj = (Game.MessageManager)ToLua.CheckObject<Game.MessageManager>(L, 1);
				UFrame.MessageCenter.Message arg0 = (UFrame.MessageCenter.Message)ToLua.CheckObject<UFrame.MessageCenter.Message>(L, 2);
				bool arg1 = LuaDLL.luaL_checkboolean(L, 3);
				obj.Send(arg0, arg1);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: Game.MessageManager.Send");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_gameMessageCenter(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Game.MessageManager obj = (Game.MessageManager)o;
			UFrame.MessageCenter.ActionMessageCenter ret = obj.gameMessageCenter;
			ToLua.PushObject(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index gameMessageCenter on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_gameMessageCenter(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Game.MessageManager obj = (Game.MessageManager)o;
			UFrame.MessageCenter.ActionMessageCenter arg0 = (UFrame.MessageCenter.ActionMessageCenter)ToLua.CheckObject<UFrame.MessageCenter.ActionMessageCenter>(L, 2);
			obj.gameMessageCenter = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index gameMessageCenter on a nil value");
		}
	}
}

