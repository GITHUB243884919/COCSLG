﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UFrame_Common_Singleton_Game_MessageManagerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UFrame.Common.Singleton<Game.MessageManager>), typeof(System.Object), "Singleton_Game_MessageManager");
		L.RegFunction("GetInstance", GetInstance);
		L.RegFunction("DestroyInstance", DestroyInstance);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetInstance(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 0);
			Game.MessageManager o = UFrame.Common.Singleton<Game.MessageManager>.GetInstance();
			ToLua.PushObject(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DestroyInstance(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 0);
			UFrame.Common.Singleton<Game.MessageManager>.DestroyInstance();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}
