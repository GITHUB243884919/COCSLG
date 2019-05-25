﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class LuaMessageCenter_MessageWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(LuaMessageCenter.Message), typeof(System.Object));
		L.RegFunction("New", _CreateLuaMessageCenter_Message);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("messageID", get_messageID, set_messageID);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateLuaMessageCenter_Message(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				LuaMessageCenter.Message obj = new LuaMessageCenter.Message();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: LuaMessageCenter.Message.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_messageID(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LuaMessageCenter.Message obj = (LuaMessageCenter.Message)o;
			int ret = obj.messageID;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index messageID on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_messageID(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LuaMessageCenter.Message obj = (LuaMessageCenter.Message)o;
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			obj.messageID = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index messageID on a nil value");
		}
	}
}
